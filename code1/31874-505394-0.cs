    protected void Page_Load(object sender, EventArgs e)
    {
      DisableChilds(this.Page);
    }
    
    private void DisableChilds(Control ctrl)
    {
       foreach (Control c in ctrl.Controls)
       {
          DisableChilds(c);
          if (c is DropDownList)
          {
               ((DropDownList)(c)).Enabled = false;
          }
        }
    }
