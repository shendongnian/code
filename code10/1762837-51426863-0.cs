    protected void ProjectGridView_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
     {
     string projectid = (ProjectGridView.SelectedRow.FindControl("LinkProjectID") as Label).Text;
     PopUpMessage(projectid);
     }
