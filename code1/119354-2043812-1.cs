    protected void gridView_RowCommand(object source, System.Web.UI.WebControls.GridViewCommandEventArgs e)
                {
                    if (e.CommandName == "Disable") 
                    {
                        UpdateArticleVisibility(true, [lblArticleID.Text value], gOrgId);
                    }
    
                    if (e.CommandName == "Enable")
                    {
                        UpdateArticleVisibility(false, [lblArticleID.Text value], gOrgId);
                    }
                }
