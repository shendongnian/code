     foreach (Control ctrl in container.Controls)
     {
       if (ctrl is TextBox)
       {
         ctrl.TextChanged += new System.EventHandler(TextBox_TextChanged);
       }
     }
