    // serverAddress = Server IP or DNS (Match SSL certificate)
    // ObjectDN = The DN of the user you are binding to
    // userName = Account which will be used to make the bind
    // password = password of the user which will make the bind
    // value = The value you wish to add to the attribute
    // Connect to the user in LDAP
    DirectoryEntry entry = new DirectoryEntry("LDAP://" + serverAddress + "/" + ObjectDN + ""
                    , userName
                    , password
                    , AuthenticationTypes.SecureSocketsLayer);
    // Write the Updated attribute
    entry.Properties["attribute"].Value = value;
    // Read back the updated Attribute into a label
    label.Text = entry.Properties["attribute"].Value.ToString();
