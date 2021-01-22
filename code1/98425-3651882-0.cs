    let devExpressTypes = Assemblies.WithNameLike("DevExpress").ChildTypes()
    let ndependTypes = Assemblies.WithNameLike("NDepend").ChildTypes()
    let publicDevExpressTypesUsed = devExpressTypes.UsedByAny(ndependTypes)
    let devExpressTypesUsedRec = publicDevExpressTypesUsed .FillIterative(
      types=> devExpressTypes.UsedByAny(types))
    
    from t in devExpressTypesUsedRec.DefinitionDomain
    select new { t, 
       depth = devExpressTypesUsedRec[t], 
       ndependTypesUsingMe = t.TypesUsingMe.Intersect(ndependTypes) 
    }
