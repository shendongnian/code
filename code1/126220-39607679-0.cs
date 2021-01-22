Using System.DirectoryServices
 public static bool IsMemberOfGroupsToCheck(string DomainServer, string LoginID, string LoginPassword)
        {
			string UserDN = "CN=John.Doe-A,OU=Administration Accounts,OU=User Directory,DC=ABC,DC=com"
            string ADGroupsDNToCheck = "CN=ADGroupTocheck,OU=Administration Groups,OU=Group Directory,DC=ABC,DC=com";
            byte[] sid, parentSID;
            bool check = false;
            DirectoryEntry parentEntry;
            DirectoryEntry basechildEntry;
            string octetSID;
                basechildEntry = new DirectoryEntry("LDAP://" + DomainServer + "/" + UserDN, LoginID, LoginPassword);
                basechildEntry.RefreshCache(new String[] { "tokenGroups" });
                parentEntry = new DirectoryEntry("LDAP://" + DomainServer + "/" + ADGroupsDNToCheck, LoginID, LoginPassword);
                parentSID = (byte[])parentEntry.Properties["objectSID"].Value;
                octetSID = ConvertToOctetString(parentSID, false, false);
                foreach(Object GroupSid in basechildEntry.Properties["tokenGroups"])
                {
                    sid = (byte[])GroupSid;
                    if (ConvertToOctetString(sid,false,false) == octetSID)
                    {
                        check = true;
                        break;
                    }
                }
                basechildEntry.Dispose();
                parentEntry.Dispose();
               
                return check;
        }
