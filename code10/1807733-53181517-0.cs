    protected void fvPhaudDets_DataBound(object sender, EventArgs e)
            {
                ((LinkButton)fvPhaudDets.FindControl("EditButton")).Visible = false;// Hides Edit button
                ((LinkButton)fvPhaudDets.FindControl("NewButton")).Visible = false;// Hides New button
                ((LinkButton)fvPhaudDets.FindControl("DeleteButton")).Visible = false;// Hides Delete button
            }
