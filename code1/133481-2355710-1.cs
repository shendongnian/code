        public static void EmptyTextBoxes(Control parent) 
        { 
         foreach (Control c in parent.Controls) { 
           if (c.GetType() == typeof(TextBox))
           { 
             ((TextBox)(c)).Text = string.Empty;            
           }  
        } 
     
