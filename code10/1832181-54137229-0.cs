     private bool IsValid()
     {
         foreach (var control in this.Controls)
         {
             if (control is TextBox textBox)
             {
                 if (!IsNumber(textBox))
                 {
                     return false;
                 }
             }
         }
         //nothing returned false, so it must be valid
         return true;
     }
