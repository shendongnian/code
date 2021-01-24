    // using Abp.Configuration.Startup;
    Configuration.ReplaceService<IEntityHistoryStore, MyEntityHistoryStore>();
    Configuration.EntityHistory.Selectors.Add(
        new NamedTypeSelector(
            "ToBeAuditedEntities",
            type => type.GetProperties().Any(p => p.IsDefined(typeof(ToBeAuditedAttribute)))
        )
    );
