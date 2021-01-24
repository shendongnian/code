    var allPolicies = _context.PolicySummary
                              .Where(policy => policyIds.Contains(policy.PolicyId))
                              .GroupBy(policy => policy.PolicyId)
                              .Select(group => new PolicySummaryDTO
                              {
                                  PolicyId = group.Key,
                                  PolicyName = group.First().PolicyName,
                                  Amount = group.First().Amount                  
                              })
                              .ToDictionary(policy => policy.PolicyId);
    foreach (var car in cars)
    {
        car.Policies = car.Policies.Select(p => p.PolicyId)
                                   .Where(allPolicies.ContainsKey)
                                   .Select(policyId => allPolicies[policyId])
                                   .ToList();
    }
