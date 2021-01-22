    public void ResetPassword(string userName, string Password, string newPassword)
            {
            try
                {
                    DirectoryEntry directoryEntry = new DirectoryEntry(Path,userName, Password);
    
                    if (directoryEntry != null)
    
                    {
                        DirectorySearcher searchEntry = new DirectorySearcher(directoryEntry );
                        searchEntry .Filter = "(samaccountname=" + userName +")";
                        SearchResult result = searchEntry.FindOne();
                        if (result != null)
                        {
                            DirectoryEntry userEntry = result.GetDirectoryEntry();
                            if (userEntry != null)
                            {
                                userEntry.Invoke("SetPassword", new object[] { newPassword });
                                userEntry.Properties["lockouttime"].Value = 0;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Password Can't Change:" + ex.InnerException.Message);
                }
            }
