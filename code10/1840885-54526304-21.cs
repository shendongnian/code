    var entities = new List<BaseEntity> { 
        new GrandChildAEntity(),
        new BaseEntity(),
        new ChildBEntity(),
        new ChildAEntity() };
    var policyResults = entities
        .Select(entity => policyProvider
            .GetPolicies<IEntityPolicy<BaseEntity>>(entity.GetType())
            .Select(policy => policy.GetPolicyResult(entity)))
        .ToList();
    // policyResults = [
    //    { "GrandChildAEntityPolicy", "BaseEntityPolicy" },
    //    { "BaseEntityPolicy" },
    //    { "ChildBEntityPolicy", "BaseEntityPolicy" }, 
    //    { "BaseEntityPolicy" }
    // ];
