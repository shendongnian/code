     protected void FormView1_DataBound(object sender, EventArgs e)
    {
        if (FormView1.CurrentMode == FormViewMode.Edit)
        {
            btn_resolve = (Button)FormView1.FindControl("btn_resolve");
            resolve.Visible = true;
        }
    }
