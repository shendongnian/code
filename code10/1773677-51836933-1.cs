    var allPolicies = _context.PolicySummary
                              .Where(policy => policyIds.Contains(policy.PolicyId))
                              .Select(policy =>
                              {
                                  return new PolicySummaryDTO
                                  {
                                      PolicyId = policy.PolicyId,
                                      PolicyName = policy.PolicyName,
                                      Amount = policy.Amount
                                  };
                              })
                              .ToDictionary(policy => policy.PolicyId);
    foreach (var car in cars)
    {
        car.Policies = car.Policies.Select(p => p.PolicyId)
                                   .Where(allPolicies.ContainsKey)
                                   .Select(policyId => allPolicies[policyId])
                                   .ToList();
    }
