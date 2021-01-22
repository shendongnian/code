        private static void DisableControl(WebControl control)
        {
            Type controlType = control.GetType();
            if (controlType == typeof(CheckBox))
            {
                ((CheckBox)control).InputAttributes.Add("disabled", "disabled");
            }
            else if (controlType == typeof(RadioButton))
            {
                ((RadioButton)control).InputAttributes.Add("disabled", "true");
            }
            else if (controlType == typeof(ImageButton))
            {
                ((ImageButton)control).Enabled = false;
            }
            else
            {
                control.Attributes.Add("readonly", "readonly");
            }
        }
