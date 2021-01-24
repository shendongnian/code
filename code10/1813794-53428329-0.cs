    services.AddTransient<IEnumerable<IQualifier>>(provider => 
    {
        return new[]
        {
            new QualifierOne(),
            new QualifierTwo(),
            new QualifierThree(),
        }
    });
    services.AddTransient<ILinkQualifier, LinkQualifier>();
