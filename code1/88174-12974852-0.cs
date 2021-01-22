            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                DirectorySecurity acl = di.GetAccessControl();
                AuthorizationRuleCollection rules = acl.GetAccessRules(true, true, typeof(NTAccount));
                WindowsIdentity currentUser = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(currentUser);
                foreach (AuthorizationRule rule in rules)
                {
                    FileSystemAccessRule fsAccessRule = rule as FileSystemAccessRule;
                    if (fsAccessRule == null)
                        continue;
                    if ((fsAccessRule.FileSystemRights & FileSystemRights.WriteData) > 0)
                    {
                        NTAccount ntAccount = rule.IdentityReference as NTAccount;
                        if (ntAccount == null)
                        {
                            continue;
                        }
                        if (principal.IsInRole(ntAccount.Value))
                        {
                            Console.WriteLine("Current user is in role of {0}, has write access", ntAccount.Value);
                            continue;
                        }
                        Console.WriteLine("Current user is not in role of {0}, does not have write access", ntAccount.Value);                        
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("does not have write access");
            }
