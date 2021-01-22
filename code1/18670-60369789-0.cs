     using System.DirectoryServices;
     using System.DirectoryServices.Protocols;
     using System.DirectoryServices.AccountManagement;
     using System.Net; 
    private void AuthUser() { 
            
          try{
                string Uid = "USER_NAME";
                string Pass = "PASSWORD";
                if (Uid == "")
                {
                    MessageBox.Show("Username cannot be null");
                }
                else if (Pass == "")
                {
                    MessageBox.Show("Password cannot be null");
                }
                else
                {
                    LdapConnection connection = new LdapConnection("YOUR DOMAIN");
                    NetworkCredential credential = new NetworkCredential(Uid, Pass);
                    connection.Credential = credential;
                    connection.Bind();
                    // after authenticate Loading user details to data table
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Uid);
                    DirectoryEntry up_User = (DirectoryEntry)user.GetUnderlyingObject();
                    DirectorySearcher deSearch = new DirectorySearcher(up_User);
                    SearchResultCollection results = deSearch.FindAll();
                    ResultPropertyCollection rpc = results[0].Properties;
                    DataTable dt = new DataTable();
                    DataRow toInsert = dt.NewRow();
                    dt.Rows.InsertAt(toInsert, 0);
                     
                    foreach (string rp in rpc.PropertyNames)
                    {
                        if (rpc[rp][0].ToString() != "System.Byte[]")
                        {
                            dt.Columns.Add(rp.ToString(), typeof(System.String));
                            foreach (DataRow row in dt.Rows)
                            {
                                row[rp.ToString()] = rpc[rp][0].ToString();
                            }
                           
                        }  
                    }
                 //You can load data to grid view and see for reference only
                     dataGridView1.DataSource = dt;
                }
            } //Error Handling part
            catch (LdapException lexc)
            {
                String error = lexc.ServerErrorMessage;
                string pp = error.Substring(76, 4);
                string ppp = pp.Trim();
                if ("52e" == ppp)
                {
                    MessageBox.Show("Invalid Username or password, contact ADA Team");
                }
                if ("775​" == ppp)
                {
                    MessageBox.Show("User account locked, contact ADA Team");
                }
                if ("525​" == ppp)
                {
                    MessageBox.Show("User not found, contact ADA Team");
                }
                if ("530" == ppp)
                {
                    MessageBox.Show("Not permitted to logon at this time, contact ADA Team");
                }
                if ("531" == ppp)
                {
                    MessageBox.Show("Not permitted to logon at this workstation, contact ADA Team");
                }
                if ("532" == ppp)
                {
                    MessageBox.Show("Password expired, contact ADA Team");
                }
                if ("533​" == ppp)
                {
                    MessageBox.Show("Account disabled, contact ADA Team");
                }
                if ("533​" == ppp)
                {
                    MessageBox.Show("Account disabled, contact ADA Team");
                }
            } //common error handling
            catch (Exception exc)
            {
                MessageBox.Show("Invalid Username or password, contact ADA Team");
                
            }
            finally {
                tbUID.Text = "";
                tbPass.Text = "";
            
            }
        }
 
