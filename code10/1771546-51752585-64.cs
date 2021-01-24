    private void ConfigurePolicies(IServiceCollection services)
    {
        //get data by your way, here is only an example.
        var policies = new DefaultContext().AspNetPolicy
            .Include(x => x.AspNetPolicyRequirement)
            .Where(x => x.Enabled)
            .ToList();
        //map them to real policies
        services.AddAuthorization(options =>
        {
            policies.ForEach(aspNetPolicy =>
            {
                options.AddPolicy(aspNetPolicy.Name, policy =>
                {
                    foreach (var aspNetPolicyRequirement in aspNetPolicy.AspNetPolicyRequirement.Where(x=>x.Enabled))
                    {
                        switch (aspNetPolicyRequirement.RequirementType)
                        {
                            case RequirementType.Claim:
                            {
                                policy.RequireClaim(aspNetPolicyRequirement.RequirementName);
                                break;
                            }
                            case RequirementType.UserName:
                            {
                                policy.RequireUserName(aspNetPolicyRequirement.RequirementName);
                                break;
                            }
                            case RequirementType.Role:
                            {
                                policy.RequireRole(aspNetPolicyRequirement.RequirementName);
                                break;
                            }
                            case RequirementType.AuthenticatedUser:
                            {
                                policy.RequireAuthenticatedUser();
                                break;
                            }
                            case RequirementType.Assertion:
                            {
                                //policy.RequireAssertion(...);//To Do
                                break;
                            }
                        }
                    }
                });
            });
        });
    }
