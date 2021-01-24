    var context = GetCoreDbEntityContext(businessEntityId);
    var result = context.ComponentProfiles
        .Where(p => context.Components
            .Where(i => i.BusinessEntityId == businessEntityId)    // find relevant components
            .Any(c => c.ComponentId == p.ComponentId)    // include rows with matching ComponentId
        ).ToList();
    return result;    // contains list of ComponentProfiles
