    protected void formview_ItemCommand(object sender, FormViewCommandEventArgs e)
    
            {
    
                if (e.CommandName == "Edit")
                {
                    formview.DefaultMode = FormViewMode.Edit;
                    formview.DataBind();
                }
                if (e.CommandName == "Cancel")
                {
                    formview.DefaultMode = FormViewMode.ReadOnly;
                    formview.DataBind();
                }
    
            }
