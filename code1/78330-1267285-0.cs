        /// <summary>
        /// Creates the virtual directory.
        /// </summary>
        /// <param name="webSite">The web site.</param>
        /// <param name="appName">Name of the app.</param>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        /// <exception cref="Exception"><c>Exception</c>.</exception>
        public static bool CreateVirtualDirectory(string webSite, string appName, string path)
        {
            var schema = new DirectoryEntry("IIS://" + webSite + "/Schema/AppIsolated");
            bool canCreate = !(schema.Properties["Syntax"].Value.ToString().ToUpper() == "BOOLEAN");
            schema.Dispose();
            if (canCreate)
            {
                bool pathCreated = false;
                try
                {
                    var admin = new DirectoryEntry("IIS://" + webSite + "/W3SVC/1/Root");
                    //make sure folder exists
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        pathCreated = true;
                    }
                    //If the virtual directory already exists then delete it
                    IEnumerable<DirectoryEntry> matchingEntries = admin.Children.Cast<DirectoryEntry>().Where(v => v.Name == appName);
                    foreach (DirectoryEntry vd in matchingEntries)
                    {
                        admin.Invoke("Delete", new[] { vd.SchemaClassName, appName }); 
                        admin.CommitChanges();
                        break;
                    }
                    //Create and setup new virtual directory
                    DirectoryEntry vdir = admin.Children.Add(appName, "IIsWebVirtualDir");
                    vdir.Properties["Path"][0] = path;
                    vdir.Properties["AppFriendlyName"][0] = appName;
                    vdir.Properties["EnableDirBrowsing"][0] = false;
                    vdir.Properties["AccessRead"][0] = true;
                    vdir.Properties["AccessExecute"][0] = true;
                    vdir.Properties["AccessWrite"][0] = false;
                    vdir.Properties["AccessScript"][0] = true;
                    vdir.Properties["AuthNTLM"][0] = true;
                    vdir.Properties["EnableDefaultDoc"][0] = true;
                    vdir.Properties["DefaultDoc"][0] =
                        "default.aspx,default.asp,default.htm";
                    vdir.Properties["AspEnableParentPaths"][0] = true;
                    vdir.CommitChanges();
                    //the following are acceptable params
                    //INPROC = 0, OUTPROC = 1, POOLED = 2
                    vdir.Invoke("AppCreate", 1);
                    return true;
                }
                catch (Exception)
                {
                    if (pathCreated)
                        Directory.Delete(path);
                    throw;
                }
            }
            return false;
        }
