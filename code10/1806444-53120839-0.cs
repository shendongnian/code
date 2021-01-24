    this.BackColor = Control.DefaultBackColor;
    foreach (Control c in this.Controls)
    {
      if (c is Button)
      {
         var button = (Button)c;
         button.UseVisualStyleBackColor = true;
         button.BackColor = Control.DefaultBackColor;
      }
    }
