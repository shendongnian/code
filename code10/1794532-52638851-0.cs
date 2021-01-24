    // in Insert<T>
    var allPropertiesExceptKeyAndComputed = allProperties.Except(keyProperties.Union(computedProperties)).ToList();
    
    ...
    // in Update<T>
    var nonIdProps = allProperties.Except(keyProperties.Union(computedProperties)).ToList();
