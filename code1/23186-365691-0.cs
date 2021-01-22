    foreach(Control c in parentForm.Controls)
    {
       c.Click += delegate(object sender, EventArgs e)
                  {
                      if(floatyWindow != null && floatyWindow.IsFloating)
                      {
                           floatyWindow.Close();
                      }
                  };
    }
