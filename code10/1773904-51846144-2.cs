    // Use this to assert that an object created by CreateObject<T> has all of the 'default' values:
    //  -numeric values equal its 'id'
    //  -string values equal the name of the field concatenated with the 'id'
    // 
    // unsetProperties: property names that we want to assert are their default values
    // ignoreProperties: property names that we don't want to assert anything against - we should assert against these outside of this method
    public static void AssertObjectDefaultFields<T>(T obj, int id, HashSet<string> unsetProperties = null, HashSet<string> ignoreProperties = null)
    {
        // only test properties with a visible setter, otherwise it wouldnt have been set
        var properties = typeof(T).GetProperties().Where(prop => prop.GetSetMethod() != null);
        unsetProperties = unsetProperties ?? new HashSet<String>();
        ignoreProperties = ignoreProperties ?? new HashSet<String>();
    
        foreach (var property in properties)
        {
            if(!ignoreProperties.Contains(property.Name))
            {
                if (unsetProperties.Contains(property.Name))
                {
                    var defaultValue = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : null;
                    Assert.AreEqual(defaultValue, property.GetValue(obj));
                }
                else if (IsNumeric(property.PropertyType))
                {
                    Assert.AreEqual(id, property.GetValue(obj));
                }
                else if (property.PropertyType == typeof(string))
                {
                    Assert.AreEqual(property.Name + id, property.GetValue(obj));
                }
                else if (property.PropertyType == typeof(bool))
                {
                    Assert.AreEqual(true, property.GetValue(obj));
                }
            }
        }
    }
    
