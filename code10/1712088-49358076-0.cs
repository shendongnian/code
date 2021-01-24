    foreach (Control c in this.Controls)
    {
       c.MouseClick += new MouseEventHandler(
         delegate(object sender, MouseEventArgs e)
         {
           // handle the click here
         });
     }
