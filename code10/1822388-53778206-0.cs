    object objectToSearch = ...
       
    PropertyInfo[] properties = objectToSearch.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
    if (properties != null && properties.Length > 0)
    {
        properties.ToList().ForEach(p =>
        {
            if (p.GetCustomAttributes(typeof(AggregateAuthorizeIdentifierAttribute), false).Count() == 1)
            {
                // Do something with the property
            }
        });
    }
