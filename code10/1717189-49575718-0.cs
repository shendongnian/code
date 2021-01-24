        bool checkUserGroup()
        {
            List<GroupPrincipal> userGroups = new List<GroupPrincipal>();
            PrincipalContext currentDomain = new PrincipalContext(ContextType.Domain);
            UserPrincipal usr = UserPrincipal.FindByIdentity(currentDomain, "yourUserName");
         
            if (usr != null)
            {
                PrincipalSearchResult<Principal> foundGroups = usr.GetAuthorizationGroups();
                foreach (Principal p in foundGroups)
                {
                    if (p is GroupPrincipal)
                    {
                        userGroups.Add((GroupPrincipal)p);
                    }
                }
            }
            return userGroups.Any(ro => ro.Name == "Administrators"); //Administrtor keyword can vary depending on the cultur.
        }
