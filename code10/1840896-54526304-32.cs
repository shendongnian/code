    var grandChild = new GrandChildAEntity();
    var policyResults = policyProvider
        .GetPolicies<IEntityPolicy<BaseEntity>>(grandChild.GetType())
        .Select(x => x.GetPolicyResult(x));
    // policyResults == { "GrandChildAEntityPolicy", "BaseEntityPolicy" }
