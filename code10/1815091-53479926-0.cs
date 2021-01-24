    // using Microsoft.Azure.Management.Fluent;
    // using Microsoft.Azure.Management.ServiceBus.Fluent;
    // using Microsoft.Azure.Management.ServiceBus.Fluent.Models;
    
    string policyName = "ListenAndSendPolicy";
    
    // Define the claims
    IList<AccessRights?> rights = new List<AccessRights?>();
    rights.Add(AccessRights.Send);
    rights.Add(AccessRights.Listen);
    
    // Create the rule
    SharedAccessAuthorizationRuleInner rule = await serviceBus.AuthorizationRules.Inner.CreateOrUpdateAuthorizationRuleAsync(
        serviceBus.ResourceGroupName,
        serviceBus.Name,
        policyName,
        rights);
    
    // Get the policy
    policy = await serviceBus.AuthorizationRules.GetByNameAsync(policyName);
