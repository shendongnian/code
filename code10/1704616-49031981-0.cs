     static async void populateGroups(string ADGroupName)
        {
            // set up domain context
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // find the group in question
            GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, ADGroupName);
            // if found....
            if (group != null)
            {
                // iterate over members
                foreach (Principal p in group.GetMembers())
                {
                   // Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                    // do whatever you need to do to those members
                    UserPrincipal theUser = p as UserPrincipal;
                    
                    
                    if (theUser != null)
                    {
                        if (theUser.IsAccountLockedOut())
                        {
                            Console.WriteLine("The user: {0} is member of following Group {1}", theUser, ADGroupName);
                        }
                        else
                        {
                            Console.WriteLine("The user: {0} is member of following Group {1}", theUser, ADGroupName);
                        }
            
                    }
                }
            }
        }
