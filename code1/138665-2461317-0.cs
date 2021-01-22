    protected void GridView_OnRowCreated(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          (e.Row.FindControl("ibtnEdit") as ImageButton). PostBackUrl = "~/Edit_SyatemEmails.aspx?blogentry=edit&id=" + DataBinder.Eval(e.Row.DataItem, "SystemEmailID"))
        }
    }
