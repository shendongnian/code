    protected void btnShowSkillsetPopup_Click(object sender, EventArgs e)
    {
        // get the gridviewrow from the sender so we can get the datakey we need
        Button btnAddSkillsetsFromRow = sender as Button;
        GridViewRow row = (GridViewRow)btnAddSkillsetsFromRow.NamingContainer;
        Session["CapRes_ResourceRequestID"] = Convert.ToString(this.grdResources.DataKeys[row.RowIndex].Value);
        Session["CapRes_SkillsetUpdatePanel_Row"] = Convert.ToString(row.RowIndex);
        ModalPopupExtender.Show();
    }
