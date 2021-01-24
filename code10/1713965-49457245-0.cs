    var context = GetCoreDbEntityContext(businessEntityId);
    var result = context.Components
        .Where(i => i.BusinessEntityId == businessEntityId)    // find relevant components
        .Select(c => new { c.ComponentId, c.BusinessEntityId })    // isolate the fields needed
        .Distinct()    // find distinct combinations of fields
        .Join(    // inner join distinct combinations with ComponentProfiles
            context.ComponentProfiles,    // table or list to inner join with
            c => c.ComponentId,    // key selector from Components used in join
            p => p.ComponentId,    // key selector from ComponentProfiles used in join
            (c, p) => new {    // select individual fields or table(s) as needed
                c.BusinessEntityId,    // individual component business entity ID
                c,    // all Component fields
                p    // all ComponentProfile fields
            })
        .Select(r => r.p)    // (optional) reduce columns to only ComponentProfiles
        .ToList();
    return result;    // contains list of ComponentProfiles
