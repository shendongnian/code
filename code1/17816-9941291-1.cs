    protected void btnHazardRating_Click(object sender, EventArgs e)
    {
        gvPanelRole.RowDataBound += new GridViewRowEventHandler(gvPanelRole_RowDataBound);
        gvPanelRole.DataSource = dtGo;
        gvPanelRole.DataBind();
        ModalPopup.Show();
    }
