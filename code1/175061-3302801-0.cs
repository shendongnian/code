    btnDeleteSelected1.Click += Events.BtnDeleteSelected_Click;
    btnDeleteSelected2.Click += Events.BtnDeleteSelected_Click;
    ...
    btnDeleteSelected3.Click += Events.BtnDeleteSelected_Click;
    
    public static class Events
    {
      public static BtnDeleteSelected_Click(object sender, EventArgs e)
      {
         ...
      }
    }
