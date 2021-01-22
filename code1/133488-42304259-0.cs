            foreach (Control c in this.form.Controls)
            {
                //Tests each control to see if it is a GroupBox
                if (c is GroupBox)
                {
                    clearRadioButtons(c.Controls);
                    clearListBox(c.Controls);
                    resetDateTime(c.Controls);
                    clearTextBoxes(c.Controls);
                    clearComboBoxes(c.Controls);
                }
            }    
        public static void clearTextBoxes(Control.ControlCollection controls)
        {
            //Loops through all controls on form
            foreach (Control c in controls)
            {
                //Tests each control to see if it is a textbox
                if (c is TextBox)
                {
                    //Converts to useable format and clears textboxes
                    var text = (TextBox)c;
                    text.Clear();
                }
            }
        }
