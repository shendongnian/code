    protected void ddlTool_SelectedIndexChanged(object sender, EventArgs e) 
    {
      int selectedValue = int.Parse(ddlTool.SelectedValue.ToString());
      for (int i = 1; i <= 4; ++i)
      {
        bool state = i <= selectedValue;
        this.Controls["lblTool" + i.ToString()].Visible = state;
        this.Controls["txtTool" + i.ToString()].Visible = state;
      }
    }
