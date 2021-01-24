        DirectoryEntry _directoryEntry = null;
    
    
    private DirectoryEntry SearchRoot
            {
                get
                {
                    if (_directoryEntry == null)
                    {
                        _directoryEntry = new DirectoryEntry(@"LDAP://" + textBox5.Text, textBox3.Text, textBox4.Text, AuthenticationTypes.Secure);
                    }
                    return _directoryEntry;
                }
            }
    private void GetUsers(){
      List<string> userlist = new List<string>();
    
                try
                {
                    DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot)
                    {
                        Filter = "(&(objectClass=group)(SAMAccountName=" + textBox1.Text + "))"
                    };
    
    
                    directorySearch.PropertiesToLoad.Add("mail");
                    var results = directorySearch.FindOne();
    
                    if (results != null)
                    {
    
    
                        DirectoryEntry deGroup = new DirectoryEntry(results.Path, textBox3.Text, textBox4.Text);
    
                        System.DirectoryServices.PropertyCollection pColl = deGroup.Properties;
                        int count = pColl["member"].Count;
                        for (int i = 0; i < count; i++)
                        {
                            string respath = results.Path;
                            string[] pathnavigate = respath.Split("CN".ToCharArray());
                            respath = pathnavigate[0];
                            string objpath = pColl["member"][i].ToString();
                            string path = respath + objpath;
                            DirectoryEntry user = new DirectoryEntry(path, textBox3.Text, textBox4.Text);
                            User userobj = User.GetUser(user);
                            userobj.EmailAddress = GetUserEmail(userobj.LoginName);
                            userlist.Add(userobj.EmailAddress);
                            user.Close();
                        }
                    }
                    //listBox1.DataSource = userlist;
                    userlist.ForEach(item => textBox2.Text += item);
                    //var t = userlist.Where(item => !string.IsNullOrEmpty(item.FirstName) || !string.IsNullOrWhiteSpace(item.FirstName)).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace + ex.Source);
                }
    }
      public string GetUserEmail(string usr)
            {
                try
                {
    
                    string uid = textBox3.Text;
                    string pwd = textBox4.Text;
                    string emailProxy = "";
                    string emailMail = "";
                    using (var context = new PrincipalContext(ContextType.Domain, textBox5.Text, uid, pwd))
                    {
                        using (UserPrincipal user = new UserPrincipal(context))
                        {
                            user.SamAccountName = usr;
    
                            using (var searcher = new PrincipalSearcher(user))
                            {
    
                                var r = searcher.FindAll();
                                foreach (var result in r)
                                {
                                    DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
    
                                    if (de.Properties["proxyAddresses"].Value != null)
                                    {
                                        List<string> tmpAddress = new List<string>();
                                        int i = 0;
                                        while (true)
                                        {
                                            try
                                            {
                                                tmpAddress.Add(de.Properties["proxyAddresses"][i].ToString());
                                                i++;
                                            }
                                            catch { break; }
                                        }
                                        string val = tmpAddress.Where(em => em.Contains("SMTP")).FirstOrDefault();
    
                                        if (!string.IsNullOrEmpty(val))
                                            emailProxy = val.Split(':')[1];
                                        else emailProxy = "";
                                    }
                                    else emailProxy = "";
    
                                    if (de.Properties["mail"].Value != null)
                                        emailMail = de.Properties["mail"].Value.ToString();
                                    else emailMail = "";
                                }
                            }
                        }
                    }
    
                    return !string.IsNullOrEmpty(emailProxy) ? emailProxy : (!string.IsNullOrEmpty(emailMail) ? emailMail : "");
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.InnerException + ex.StackTrace + ex.Source);
                    return "";
                }
            }
     
