    foreach (Control x in this.Controls)
    {
      if (x is TextBox)
      {
        ((TextBox)x).Text = String.Empty;
    //instead of above line we can use 
         ***  x.resetText();
      }
    }
