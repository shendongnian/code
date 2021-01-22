            try
            {
                bool writeable = false;
                WindowsPrincipal principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                DirectorySecurity security = Directory.GetAccessControl(pstrPath);
                AuthorizationRuleCollection authRules = security.GetAccessRules(true, true, typeof(SecurityIdentifier));
                foreach (FileSystemAccessRule accessRule in authRules)
                {
                    
                    if (principal.IsInRole(accessRule.IdentityReference as SecurityIdentifier))
                    {
                        if ((FileSystemRights.WriteData & accessRule.FileSystemRights) == FileSystemRights.WriteData)
                        {
                            if (accessRule.AccessControlType == AccessControlType.Allow)
                            {
                                writeable = true;
                            }
                            else if (accessRule.AccessControlType == AccessControlType.Deny)
                            {
                                //Deny usually overrides any Allow
                                return false;
                            }
                        } 
                    }
                }
                return writeable;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
