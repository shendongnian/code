    protected void ASPxGridView1_DataBound(object sender, EventArgs e)
    { 
      if (!User.IsInRole(ConfigurationSettings.AppSettings["EditActiveDirectoryGroup"]))
      {
        foreach (GridViewColumn c in ASPxGridView1.Columns)
        {
          if (c.GetType() == typeof(GridViewCommandColumn))
          {
            c.Visible = false;
          }
        }
      }
    }
