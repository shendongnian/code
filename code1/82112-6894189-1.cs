        if (e.Row.RowType == DataControlRowType.Header)
        {
            Label lblHeader = (Label)e.Row.FindControl("lblHeader");
            lblHeader.Text = ViewState["Header_Name"].ToString();
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnk = (LinkButton)e.Row.FindControl("lnkDisplay_Text");
            lnk.OnClientClick = "Close_Window('" + lnk.CommandArgument + "','" + ViewState["ID_Field"].ToString() 
                + "')";
        }
    }
    protected void grdSearch_Result_RowCreated(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[2].Visible = false;
        e.Row.Cells[3].Visible = false;
    }
    
}
