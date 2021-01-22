    for(int index = 1; index <= Convert.ToInt32(ddlTool.SelectedValue); index++)
    {
        this.Controls["lblTool" + index.ToString()].Visible = true;
        this.Controls["txtTool" + index.ToString()].Visible = true;
    }
