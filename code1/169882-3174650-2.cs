    var properties = myEntity.GetType().GetProperties();
    
    foreach (string ky in ld.Keys)
    {
        var matchingProperty = properties.Where(p => p.Name.Equals(ky)).FirstOrDefault();
        if (matchingProperty != null)
        {
            matchingProperty.SetValue(myEntity, ld[ky], null);
        }
    }
