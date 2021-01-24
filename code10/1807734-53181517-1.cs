    protected void fvPhaudDets_DataBound(object sender, EventArgs e)
            {
              ((LinkButton) ((FormView)sender).FindControl("EditButton")).Visible = false;// Hides Edit button
              ((LinkButton) ((FormView)sender).FindControl("NewButton")).Visible = false;// Hides New button
              ((LinkButton) ((FormView)sender).FindControl("DeleteButton")).Visible = false;// Hides Delete button
            }
