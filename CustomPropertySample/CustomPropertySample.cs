using System;
using System.Globalization;
using Meedio;
using MeedioExtensions;




namespace CustomPropertySample {

    public class CustomPropertySample : IMLImportPlugin
    {
    
        public bool GetProperty(int Index, IMeedioPluginProperty Property) 
        {
      Int32 counter = 1;
      if (Index == counter++) {
        Property.CanTypeChoices = false;
        Property.Caption = "Custom Properties";
        Property.DataType = "custom";
        Property.DefaultValue = myProperties.Default;
        Property.Name = "custom";
        return true;
      }
      return false;
    }

    public bool EditCustomProperty(int Window, String PropertyName, ref String Value) {
      if (PropertyName == "custom") {
        myProperties.Initialize("Custom Properties", Value);
        if (myProperties.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
          Value = myProperties.Value;
          return true;
        } else {
          return false;
        }
      } else {
        return true;
      }
    }

    public bool SetProperties(IMeedioItem Properties, out String ErrorText) {
      ErrorText = "";
      try {
        if (Properties["custom"] != null) {
          MyProperties.SetProperties(ref Properties, "custom");
        }
        if (Properties["bool"] != null) {
          boolProperty = (Boolean)Properties["bool"];
        }
        if (Properties["char"] != null) {
          charProperty = (String)Properties["char"];
        }
        if (Properties["choices"] != null) {
          choicesProperty = (String)Properties["choices"];
        }
        if (Properties["choices2"] != null) {
          choices2Property = (String)Properties["choices2"];
        }
        if (Properties["date"] != null) {
          dateProperty = (String)Properties["date"];
        }
        if (Properties["file"] != null) {
          fileProperty = (String)Properties["file"];
        }
        if (Properties["float"] != null) {
          floatProperty = (Single)Properties["float"];
        }
        if (Properties["folder"] != null) {
          folderProperty = (String)Properties["folderProperty"];
        }
        if (Properties["folderlist"] != null) {
          folderlistProperty = (String[])Properties["folderlist"];
        }
        if (Properties["int"] != null) {
          intProperty = (Int32)Properties["int"];
        }
        if (Properties["maskedtextbox"] != null) {
          maskedtextboxProperty = (String)Properties["maskedtextbox"];
        }
        if (Properties["numericupdown"] != null) {
          numericupdownProperty = (Single)Properties["numericupdown"];
        }
        if (Properties["password"] != null) {
          passwordProperty = (String)Properties["password"];
        }
        if (Properties["section"] != null) {
          sectionProperty = (String)Properties["section"];
        }
        if (Properties["string"] != null) {
          stringProperty = (String)Properties["string"];
        }
        if (Properties["stringlist"] != null) {
          stringlistProperty = (String[])Properties["stringlist"];
        }
        if (Properties["time"] != null) {
          timeProperty = (String)Properties["time"];
        }
        if (Properties["trackbar"] != null) {
          trackbarProperty = (Int32)Properties["trackbar"];
        }
      } catch (Exception exception) {
        ErrorText = exception.Message;
        return false;
      }
      return true;
    }

    public bool Import(IMLSection Section, IMLImportProgress Progress) {
      String messageBox = String.Empty;
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "bool: " + boolProperty.ToString(CultureInfo.InvariantCulture);
        if (charProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "char: " + charProperty;
      }
      if (choicesProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "choices: " + choicesProperty;
      }
      if (choices2Property != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "choices2: " + choices2Property;
      }
      if (dateProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "date: " + dateProperty;
      }
      if (fileProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "file: " + fileProperty;
      }
      if (folderProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "folder: " + folderProperty;
      }
      if (folderlistProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "folderlist:";
        foreach (String temp in folderlistProperty) {
          messageBox += ((messageBox.EndsWith("folderlist:")) ? "\t" : "\r\n\t") + temp;
        }
      }
      if (intProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "int: " + intProperty.ToString();
      }
      if (maskedtextboxProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "maskedtextbox: " + maskedtextboxProperty;
      }
      if (numericupdownProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "numericupdown: " + numericupdownProperty.ToString();
      }
      if (passwordProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "password: " + passwordProperty;
      }
      if (sectionProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "section: " + sectionProperty;
      }
      if (stringProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "string: " + stringProperty;
      }
      if (stringlistProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "stringlist:";
        foreach (String temp in stringlistProperty) {
          messageBox += ((messageBox.EndsWith("stringlist:")) ? "\t" : "\r\n\t") + temp;
        }
      }
      if (timeProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "time: " + timeProperty;
      }
      if (trackbarProperty != null) {
        messageBox += ((messageBox == String.Empty) ? "" : "\r\n") + "trackbar: " + trackbarProperty.ToString();
      }
      System.Windows.Forms.MessageBox.Show(messageBox);
      return true;
    }

    MyProperties myProperties = new MyProperties();

    Boolean boolProperty;
    String charProperty;
    String choicesProperty;
    String choices2Property;
    String dateProperty;
    String fileProperty;
    Single floatProperty;
    String folderProperty;
    String[] folderlistProperty;
    Int32 intProperty;
    Single numericupdownProperty;
    String maskedtextboxProperty;
    String passwordProperty;
    String sectionProperty;
    String stringProperty;
    String[] stringlistProperty;
    String timeProperty;
    Int32 trackbarProperty;
  }

  class MyProperties : CustomProperty {
    public override bool GetProperty(int Index, ref IMeedioExtensionsPluginProperty Property) {
      Int32 counter = 1;
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"bool\" DataType";
        Property.DataType = "bool";
        Property.DefaultValue = false;
        Property.Enabled = true;
        Property.GroupCaption = "Meedio Custom Properties Extensions";
        Property.HelpText = "This is a checkbox";
        Property.IsMandatory = false;
        Property.Name = "bool";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"char\" DataType";
        Property.DataType = "char";
        Property.DefaultValue = "A";
        Property.Enabled = true;
        Property.HelpText = "This is a textbox (maxlength: 1)";
        Property.IsMandatory = false;
        Property.Name = "char";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"choices\" Property";
        Property.Choices = new String[] { "Choice1", "Choice2" };
        Property.DataType = "string";
        Property.DefaultValue = "Choice1";
        Property.Enabled = true;
        Property.HelpText = "This is a combobox";
        Property.IsMandatory = false;
        Property.Name = "choices";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = false;
        Property.Caption = "A \"choices2\" Property";
        Property.Choices2["A"] = "Choice1";
        Property.Choices2["B"] = "Choice2";
        Property.DataType = "string";
        Property.DefaultValue = "Choice1";
        Property.Enabled = true;
        Property.HelpText = "This is a combobox";
        Property.IsMandatory = false;
        Property.Name = "choices2";
        return true;
      }
      if (Index == counter++) {
        Property.Caption = "A \"date\" DataType";
        Property.DataType = "date";
        Property.DefaultValue = "1979-12-27";
        Property.Enabled = true;
        Property.HelpText = "This is a datetimepicker";
        Property.IsMandatory = false;
        Property.Name = "date";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"file\" DataType";
        Property.DataType = "file";
        Property.Enabled = true;
        Property.HelpText = "This is a textbox and browse button";
        Property.IsMandatory = false;
        Property.Name = "file";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"float\" DataType";
        Property.DataType = "float";
        Property.DefaultValue = 1.5F;
        Property.Enabled = true;
        Property.HelpText = "This is a textbox";
        Property.IsMandatory = false;
        Property.Name = "float";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"folder\" DataType";
        Property.DataType = "folder";
        Property.Enabled = true;
        Property.HelpText = "This is a textbox and browse button";
        Property.IsMandatory = false;
        Property.Name = "folder";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"folderlist\" DataType";
        Property.DataType = "folderlist";
        Property.Enabled = true;
        Property.HelpText = "This is a textbox and browse button (launches a subwindow)";
        Property.IsMandatory = false;
        Property.Name = "folderlist";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "An \"int\" DataType";
        Property.DataType = "int";
        Property.DefaultValue = 0;
        Property.Enabled = true;
        Property.HelpText = "This is a textbox";
        Property.IsMandatory = false;
        Property.Name = "int";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"maskedtextbox\" DataType";
        Property.DataType = "maskedtextbox";
        Property.DefaultValue = "12:34:56";
        Property.Enabled = true;
        Property.HelpText = "This is a maskedtextbox";
        Property.IsMandatory = false;
        Property.Mask = "00:00:00";
        Property.Name = "maskedtextbox";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"numericupdown\" DataType";
        Property.DataType = "numericupdown";
        Property.DecimalPlaces = 1;
        Property.DefaultValue = 1.5M;
        Property.Enabled = true;
        Property.HelpText = "This is a numericupdown";
        Property.Increment = 0.1M;
        Property.IsMandatory = false;
        Property.Maximum = 100M;
        Property.Minimum = 0M;
        Property.Name = "numericupdown";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"password\" DataType";
        Property.DataType = "password";
        Property.DefaultValue = "password";
        Property.Enabled = true;
        Property.HelpText = "This is an obfuscated textbox";
        Property.IsMandatory = false;
        Property.Name = "password";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"section\" DataType";
        Property.DataType = "section";
        Property.Enabled = true;
        Property.HelpText = "This is a combobox";
        Property.IsMandatory = false;
        Property.Name = "section";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"string\" DataType";
        Property.DataType = "string";
        Property.DefaultValue = "String";
        Property.Enabled = true;
        Property.HelpText = "This is a textbox";
        Property.IsMandatory = false;
        Property.Name = "string";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"stringlist\" DataType";
        Property.DataType = "stringlist";
        Property.DefaultValue = new String[] { "String1", "String2" };
        Property.Enabled = true;
        Property.HelpText = "This is a textbox and browse button (launches a subwindow)";
        Property.IsMandatory = false;
        Property.Name = "stringlist";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"time\" DataType";
        Property.DataType = "time";
        Property.DefaultValue = "12:00 AM";
        Property.Enabled = true;
        Property.HelpText = "This is a maskedtextbox";
        Property.IsMandatory = false;
        Property.Name = "time";
        return true;
      }
      if (Index == counter++) {
        Property.CanTypeChoices = true;
        Property.Caption = "A \"trackbar\" DataType";
        Property.DataType = "trackbar";
        Property.DefaultValue = 50;
        Property.Enabled = true;
        Property.HelpText = "This is a numericupdown and trackbar";
        Property.Increment = 1;
        Property.IsMandatory = false;
        Property.Maximum = 100;
        Property.Minimum = 0;
        Property.Name = "trackbar";
        Property.TickFrequency = 25;
        return true;
      }
      return false;
    }
  }
}
