    protected override void InitializeDataCell(DataControlFieldCell cell, DataControlRowState rowState)
            {
                base.InitializeDataCell(cell, rowState);
    
                // First, find the textbox to validate
                TextBox textBox = null;
                foreach (Control ctrl in cell.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        textBox = ctrl as TextBox;
                    }
                    break;
                }
    
                // If no textbox is found, this means we are not in edit mode. 
                if (null != textBox)
                {
                    InitializeTextBox(cell, textBox);
                }
            }
    
    private void InitializeTextBox(DataControlFieldCell cell, TextBox textBox)
            {
                // Force an Id if none exists.
                if (string.IsNullOrEmpty(textBox.ID))
                {
                    textBox.ID = "Text" + DataField;
                }
    
                // Add RequiredFieldValidator
                var required = new RequiredFieldValidator {ControlToValidate = textBox.ID, Display = ValidatorDisplay.Dynamic, ErrorMessage = ErrorMsgRequired};
                validators.Add(required);
                cell.Controls.Add(required);
            }
