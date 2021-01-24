    protected void LinkProjectNumber_Click(object sender, EventArgs e)
    {
         string projectid = ((sender as LinkButton).NamingContainer.FindControl("lblProjectID") as Label).Text;
         PopUpMessage(projectid);
    }
