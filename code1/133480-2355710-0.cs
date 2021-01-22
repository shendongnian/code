    public static void EmptyTextBoxes(Control parent, TextBox tb) 
        { 
         foreach (Control c in parent.Controls) { 
           if (c.GetType() == typeof(TextBox)) { 
             ((TextBox)(c)).Text = string.Empty; 
             tb.Focus(); 
           } else if (c.GetType == typeof(DropDownList)) { 
             ((DropDownList)(c)).SelectedIndex = 0; 
           } 
           if (c.HasControls) { 
             EmptyTextBoxes(c, tb); 
           } 
         } 
        }
