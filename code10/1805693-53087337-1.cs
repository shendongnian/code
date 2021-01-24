     public void CleanTextBox(Control.ControlCollection controls)
     {
         foreach(var textbox in controls.OfType<TextBox>())
         {
            textbox.Text = "";
         }
     }
