        string userAccessText = UserAccess.Text;
        await Task.Run(() =>
        {
            //this.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
            //        {
                        for (var i = 0; i <= strServersCount - 1; i++)
                        {
                            try
                            {
                                DirectoryEntry directoryServers = new DirectoryEntry("WinNT://" + strServers[i] + ",computer");
                                DirectoryEntry directoryGroup = directoryServers.Children.Find(userAccessText + ",group");
                                object members = directoryGroup.Invoke("members", null);
                                foreach (object GroupMember in (IEnumerable)members)
                                {
                                    DirectoryEntry directoryMember = new DirectoryEntry(GroupMember);
                                    Console.WriteLine(directoryMember.Name + " | " + directoryMember.Path);
                                    temptable.Rows.Add(strServers[i], directoryMember.Name + " | " + directoryMember.Path);
                                }
                            }
                            catch (Exception ex)
                            {
                                temptable.Rows.Add(strServers[i], "Error: " + ex.InnerException + " | " + ex.Message);
                            }
                          //  DataGridResult.ItemsSource = temptable.DefaultView;
                         //   ButtonRun.IsEnabled = true;
                        }
               //     }));  // End of Invoke
        });  
        DataGridResult.ItemsSource = temptable.DefaultView;
        ButtonRun.IsEnabled = true;
