    private string GetPrimaryGroup(DirectoryEntry aEntry, DirectoryEntry aDomainEntry)
    {
       int primaryGroupID = (int)aEntry.Properties["primaryGroupID"].Value;
       byte[] objectSid = (byte[])aEntry.Properties["objectSid"].Value;
    
       StringBuilder escapedGroupSid = new StringBuilder();
       
       // Copy over everything but the last four bytes(sub-authority)
       // Doing so gives us the RID of the domain
       for(uint i = 0; i < objectSid.Length - 4; i++)
       {
            escapedGroupSid.AppendFormat("\\{0:x2}", objectSid[i]);
       }
    
       //Add the primaryGroupID to the escape string to build the SID of the primaryGroup
       for(uint i = 0; i < 4; i++)
       {
           escapedGroupSid.AppendFormat("\\{0:x2}", (primaryGroupID & 0xFF));
           primaryGroupID >>= 8;
       }
    
       //Search the directory for a group with this SID
       DirectorySearcher searcher = new DirectorySearcher();
       if(aDomainEntry != null)
       {
          searcher.SearchRoot = aDomainEntry;
       }
    			
       searcher.Filter = "(&(objectCategory=Group)(objectSID=" + escapedGroupSid.ToString() + "))";
       searcher.PropertiesToLoad.Add("distinguishedName");
       
       return searcher.FindOne().Properties["distinguishedName"][0].ToString();
    }
