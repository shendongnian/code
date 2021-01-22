    public List<GroupPrincipal> GetGroups(string userName)
        {
            var result = new List<GroupPrincipal>();
            PrincipalContext ctx = GetContext(); /*function to get domain context*/
            UserPrincipal user = UserPrincipal.FindByIdentity(ctx, userName);
            if (user != null)
            {
                PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();
                var iterGroup = groups.GetEnumerator();
                using (iterGroup)
                {
                    while (iterGroup.MoveNext())
                    {
                        try
                        {
                            Principal p = iterGroup.Current;
                            result.Add((GroupPrincipal) p);
                        }
                        catch (PrincipalOperationException)
                        {
                            continue;
                        }
                    }
                }
            }
            return result;
        }
