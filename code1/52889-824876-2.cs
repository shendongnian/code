    using (SvnClient client = new SvnClient())
    {
        client.Authentication.Clear(); // Clear predefined handlers
        // Install a custom username handler
        client.Authentication.UserNameHandlers +=
            delegate(object sender, SvnUserNameEventArgs e)
            {
                e.UserName = "MyName";
            };
 
        SvnCommitArgs ca = new SvnCommitArgs { LogMessage = "Hello" }
        client.Commit(dir, ca);
    }
