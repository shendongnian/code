    foreach (Control control in this.Controls)
    {
         if(control.GetType() == typeof(Button))
         {
                ((Button)control).BackColor = Color.Red;
         }
    }
