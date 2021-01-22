    foreach(var np in contactEntity.NavigationProperties)
    {
        Console.WriteLine("Include: {0}", np.Name);
        Console.WriteLine("... Recursively include );
        EntityType relatedType = (navProp.ToEndMember.TypeUsage.EdmType as RefType).ElementType;
        //TODO: go repeat the same process... i.e. look at the relatedTypes 
        // navProps too until you decide to stop.
    }
