     public class CheckADGroupHandler : AuthorizationHandler<CheckADGroupRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                           CheckADGroupRequirement requirement)
            {
            var groups = new List<string>();
            var wi = (WindowsIdentity)context.User.Identity;
            if (wi.Groups != null)
            {
                foreach (var group in wi.Groups)
                {
                    try
                    {
                        groups.Add(group.Translate(typeof(NTAccount)).ToString());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                foreach (string policygroup in requirement.GroupName)
                {
                    if (groups.Contains(policygroup))
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
