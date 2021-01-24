    BsonClassMap.RegisterClassMap<Claim>(cm =>
    {
        cm.SetIgnoreExtraElements(true);
        cm.MapMember(c => c.Issuer);
        cm.MapMember(c => c.OriginalIssuer);
        cm.MapMember(c => c.Properties);
        cm.MapMember(c => c.Subject);
        cm.MapMember(c => c.Type);
        cm.MapMember(c => c.Value);
        cm.MapMember(c => c.ValueType);
        cm.MapCreator(c => new Claim(c.Type, c.Value, c.ValueType, c.Issuer, c.OriginalIssuer, c.Subject));
    });
