    try
            {
                string username= txtusrid.Text.ToLower().Trim();
                string usrpwd= txtpwd.Text.Trim();
                cn= new SqlConnection(ConfigurationManager.ConnectionStrings["cntx"].ConnectionString);
                cn.Open();
                sqlcmd = new SqlCommand("_pdblogin", cn);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add(new SqlParameter("@Employee_Id", SqlDbType.NVarChar, 2500));
                sqlcmd.Parameters.Add(new SqlParameter("@pwd", SqlDbType.NVarChar, 2500));
                sqlcmd.Parameters["@Employee_Id"].Value = username;
                sqlcmd.Parameters["@pwd"].Value = usrpwd;
                reader = sqlcmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        usrfname = reader.GetValue(4).ToString();
                        Session["User"] = reader.GetValue(1).ToString();
                    }
                    if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {
                        FormsAuthentication.SetAuthCookie(username, remcbx.Checked);
                        Response.Redirect(Request.QueryString["ReturnUrl"]);
                    }
                    else
                    {
                        FormsAuthentication.RedirectFromLoginPage(username, remcbx.Checked);
                        Response.Redirect("/Userdashboard");
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    dvMessage.Visible = true;
                    errmsg.Text= "Username and/or password is incorrect.";
                }
            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                cn.Close();
            }
