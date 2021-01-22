    public bool IsUserInSecurityGroup(string user, string group)
        {
            return IsUserInGroup(user, group, "tokenGroups");
        }
        public bool IsUserInAllGroup(string user, string group)
        {
            return IsUserInGroup(user, group, "tokenGroupsGlobalAndUniversal");
        }
        private bool IsUserInGroup(string user, string group, string groupType)
        {
            var userGroups = GetUserGroupIds(user, groupType);
            var groupTokens = ParseDomainQualifiedName(group, "group");
            using (var groupContext = new PrincipalContext(ContextType.Domain, groupTokens[0]))
            {
                using (var identity = GroupPrincipal.FindByIdentity(groupContext, IdentityType.SamAccountName, groupTokens[1]))
                {
                    if (identity == null)
                        return false;
                    return userGroups.Contains(identity.Sid);
                }
            }
        }
        private List<SecurityIdentifier> GetUserGroupIds(string user, string groupType)
        {
            var userTokens = ParseDomainQualifiedName(user, "user");
            using (var userContext = new PrincipalContext(ContextType.Domain, userTokens[0]))
            {
                using (var identity = UserPrincipal.FindByIdentity(userContext, IdentityType.SamAccountName, userTokens[1]))
                {
                    if (identity == null)
                        return new List<SecurityIdentifier>();
                    var userEntry = identity.GetUnderlyingObject() as DirectoryEntry;
                    userEntry.RefreshCache(new[] { groupType });
                    return (from byte[] sid in userEntry.Properties[groupType]
                            select new SecurityIdentifier(sid, 0)).ToList();
                }
            }
        }
        private static string[] ParseDomainQualifiedName(string name, string parameterName)
        {
            var groupTokens = name.Split(new[] {"\\"}, StringSplitOptions.RemoveEmptyEntries);
            if (groupTokens.Length < 2)
                throw new ArgumentException(Resources.Exception_NameNotDomainQualified + name, parameterName);
            return groupTokens;
        }
