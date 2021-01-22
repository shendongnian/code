    public DriversLicenseMap()
    {
            UseCompositeId().WithKeyReference( x => x.Person ).Cascade.All();
            Map( x => x.State );
    }
