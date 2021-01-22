            string remotePath = @"\\server\share$";
            bool haveAccess = false;
            DirectoryInfo di = new DirectoryInfo(remotePath);
            if (di.Exists)
            {
                try
                {
                    // you could also call GetDirectories or GetFiles
                    // to test them individually
                    // this will throw an exception if you don't have 
                    // rights to the directory, though
                    var acl = di.GetAccessControl();
                    haveAccess = true;
                }
                catch (UnauthorizedAccessException uae)
                {
                    if (uae.Message.Contains("read-only"))
                    {
                        // seems like it is just read-only
                        haveAccess = true;
                    }
                    // no access, sorry
                    // do something else...
                }
            }
