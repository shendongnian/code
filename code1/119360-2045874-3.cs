    bool IsUserInGroup(string name, string group)
    {
        bool bRet = false;
        ObjectQuery query = new ObjectQuery(String.Format("SELECT * FROM Win32_UserAccount WHERE Name='{0}' AND LocalAccount=True", name));
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        ManagementObjectCollection objs = searcher.Get();
                        
        foreach (ManagementObject o in objs)
        {
            ManagementObjectCollection coll = o.GetRelated("Win32_Group");
            foreach (ManagementObject g in coll)
            {
                bool local = (bool)g["LocalAccount"];
                string groupName = (string)g["Name"];
                if (local && groupName.Equals(group, StringComparison.InvariantCultureIgnoreCase))
                {
                    bRet = true;
                    break;
                }
            }
        }           
        return bRet;
    }
