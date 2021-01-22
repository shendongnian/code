    private void BindClientTypes()
            {
                DataTable dt = DB.GetAllClientTypes();
    
                if (dt == null)
                {
                    ltGlobalErrorMsg.Text = GlobalErrorMessage;
                    ltGlobalErrorMsg.Visible = true;
                }
                else
                {
                    ddlClient.DataSource = dt;
                    ddlClient.DataValueField = "ID";
                    ddlClient.DataTextField = "Name";
                    ddlClient.DataBind();
                    //ddlClient.Items.Insert(0, PleaseSelectItem);
                }
            }
