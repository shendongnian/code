    public RadioButton GetCheckedRadioButton(Control container)
    {
        if (container == null) {
            return null;
        }
        elseif (container is RadioButton) {
            return GetCheckedRadioButton(container.Parent);
        }
        else {
            foreach (Control childControl in container.Controls) {
                if (childControl is RadioButton) {
                    RadioButton radioBtn = (RadioButton) childControl;
                    
                    if (radioBtn.Checked) {
                        return radioBtn;
                    }
                }
            }
            
            return null;
        }
    }
