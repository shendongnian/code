    private object GetValueBySectionFlag(object obj, string flagName)
    {
        // get the type:
        var objType = obj.GetType();
        
                    // iterate the properties
        var prop = (from property in objType.GetProperties()
                    // iterate it's attributes
                    from attrib in property.GetCustomAttributes(typeof(SectionFlagAttribute), false).Cast<SectionFlagAttribute>()
                    // filter on the name
                    where attrib.Name == flagName
                    // select the propertyInfo
                    select property).FirstOrDefault();
        // use the propertyinfo to get the instance->property value
        return prop?.GetValue(obj);
    }
