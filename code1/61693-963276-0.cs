    public void AssignUserToRoles_Activate(object sender, EventArgs e)
            {
                try
                {
                    AvailableRoles.DataSource = Roles.GetAllRoles().Except(new [] {"System Administrator"});
                    AvailableRoles.DataBind();
                }
                catch (Exception err)
                {
                    //
                }
            }
