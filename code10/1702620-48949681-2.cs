    IEnumerable<string> propertyNames = new string[]
    {
        "Id", "FirstName", "MiddleName", "LastName",
        "Street", "City", "PostCode",
    };
    IEnumerable<PropertyInfo> propertiesToDisplay = propertyNames
        .Select(propertyName => typeof<Student>.GetProperty(propertyName));
