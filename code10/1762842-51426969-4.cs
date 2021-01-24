    protected void LinkProjectNumber_Click(object sender, EventArgs e)
    {
         string projectid = (((sender as LinkButton).Parent as GridViewRow).FindControl("lblProjectID") as Label).Text;
         PopUpMessage(projectid);
    }
