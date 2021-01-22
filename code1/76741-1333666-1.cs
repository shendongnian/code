    public bool IsAssignedAPermission(string premissionName, string userLoginName)
        {
            XmlNode nodes;
            bool isAssignedAPermission;
            isAssignedAPermission = false;
            //Check if user is directly assigned a Full Control role
            try
            {
                nodes = userGroupService.GetRoleCollectionFromUser(userLoginName);
                using (XmlNodeReader reader = new XmlNodeReader(nodes))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(reader);
                    DataTable dt = ds.Tables[1];
                    foreach (DataRow row in dt.Rows)
                    {
                        string permission = row[1].ToString();
                        if (permission == premissionName)
                        {
                            isAssignedAPermission = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                List<string> groupMemberships;
                List<string> fullControlGroups;
                //Check if user is a member of a Full Control group
                //This is done in three steps:
                //1. Get the list of groups the user is member of
                groupMemberships = new List<string>();
                nodes = userGroupService.GetGroupCollectionFromUser(userLoginName);
                using (XmlNodeReader reader = new XmlNodeReader(nodes))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(reader);
                    DataTable dt = ds.Tables[1];
                    foreach (DataRow row in dt.Rows)
                    {
                        string groupName = row[1].ToString();
                        groupMemberships.Add(groupName);
                    }
                }
                //2. Get the list of groups that have Full Control permissions
                fullControlGroups = new List<string>();
                nodes = userGroupService.GetGroupCollectionFromRole(premissionName);
                using (XmlNodeReader reader = new XmlNodeReader(nodes))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(reader);
                    DataTable dt = ds.Tables[1];
                    foreach (DataRow row in dt.Rows)
                    {
                        string groupName = row[1].ToString();
                        fullControlGroups.Add(groupName);
                    }
                }
                //3. Check if user belongs to any of the Full Control groups
                foreach (string membership in groupMemberships)
                {
                    if (fullControlGroups.Contains(membership))
                    {
                        isAssignedAPermission = true;
                        break;
                    }
                }
            }
            return isAssignedAPermission;
        }
