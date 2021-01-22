    public void ShowChangeSetDetails(Form owner, Changeset changeSet)
            {
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                Assembly vcControls = Assembly.LoadFrom(path + @"\Microsoft.TeamFoundation.VersionControl.Controls.dll");
                Assembly vcClient = Assembly.LoadFrom(path + @"\Microsoft.TeamFoundation.VersionControl.Client.dll");
    
                Type dialogChangesetDetailsType = 
                    vcControls.GetType("Microsoft.TeamFoundation.VersionControl.Controls.DialogChangesetDetails", true);
    
                MethodInfo methodInfo = 
                    dialogChangesetDetailsType.GetMethod(
                        "ShowChangeset", 
                        BindingFlags.Static | BindingFlags.NonPublic, 
                        null, 
                        new Type[] { typeof(IWin32Window), changeSet.VersionControlServer.GetType(), changeSet.GetType(), typeof(bool) }, 
                        null);
                methodInfo.Invoke(null, new object[] { owner, changeSet.VersionControlServer, changeSet, true });
            }
