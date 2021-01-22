        public bool IsUserMemberOfGroup(string userName, string groupName)
        {
            bool ret = false;
            
            try
            {
                DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
                DirectoryEntry userGroup = localMachine.Children.Find(groupName, "group");
                object members = userGroup.Invoke("members", null);
                foreach (object groupMember in (IEnumerable)members)
                {
                    DirectoryEntry member = new DirectoryEntry(groupMember);
                    if (member.Name.Equals(userName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        ret = true;
                       break;
                    }
                }
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
