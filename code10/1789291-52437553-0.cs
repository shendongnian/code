    bool areOneOrMoreFieldsEmpty()
    {
        var textboxControls = GetType().GetFields().Where(field => field.Name.StartsWith("txtvalue");
   
        foreach(var control in textboxControls)
        {
            var textValueProperty = control.GetProperty(nameof(TextBoxControl.Text));
            var stringValue = textValueProperty.GetValue(this, null) as string;       
            if (string.IsNullOrEmpty(stringValue) || stringValue == "0")
            {
                  return false;
            }
        }
        return true;
    }
   
