        private void ProcessControl(TextBox textbox, bool IsRead)
        {
            //1. textbox.Name; - Control name
            //2. Text                 - Control property
            //3. textbox.Text  - Control value
            if (IsRead)
            {
                                        // Class that reads the XML file saving the state of the visual elements
                textbox.Text = LogicStatePreserver.GetValue(textbox).ToString();
            }
            else
            {
                LogicStatePreserver.UpdateControlValue(textbox, textbox.Text);
            }
        }
