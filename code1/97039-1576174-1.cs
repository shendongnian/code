     protected void frm_DataBound(object sender, EventArgs e) 
    {
        if (frm.CurrentMode == FormViewMode.Edit) 
        {
          TextBox txtdate = (TextBox)frm.FindControl("txtdate");
          txtdate.Attributes.Add("", "");
        } 
    }
