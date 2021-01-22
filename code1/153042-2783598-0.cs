            string hostName = "myComputer";
            //get machine
            using (DirectoryEntry machine = new DirectoryEntry("WinNT://" + hostName))
            {
                //get local admin group
                using (DirectoryEntry group = machine.Children.Find("Administrators", "Group"))
                {
                    //get all members of local admin group
                    object members = group.Invoke("Members", null);
                    foreach (object member in (IEnumerable)members)
                    {
                        //get account name
                        string accountName = new DirectoryEntry(member).Name;
                        //DO SOMETHING...
                    }
                }        
            }
