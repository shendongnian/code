               Entity systemUser = new Entity("systemuser");
                systemUser.Id = Guid.NewGuid();
                fakedContext.CallerId = systemUser.ToEntityReference();
                IOrganizationService service = fakedContext.GetOrganizationService();
                Entity userSettings = new Entity("usersettings");
                userSettings.Id = Guid.NewGuid();
                userSettings["timezonecode"] = 71;
                userSettings["systemuserid"] = systemUser.ToEntityReference();
