    public void Should_Use_Magic_To_Get_CustomAttributes_From_Ancestry()
    {
    
        Assert.AreEqual(checkAttributeCount (typeof (Sedan), "TurningRadious"), 3);
    }
    
    
    int checkAttributeCount (Type type, string propertyName)
    {
            var attributesCount = 0;
    
            attributesCount += countAttributes (type, propertyName);
            while (type.BaseType != null)
            {
                type = type.BaseType;
                attributesCount += countAttributes (type, propertyName);
            }
    
            foreach (var i in type.GetInterfaces ())
                attributesCount += countAttributes (type, propertyName);
            return attributesCount;
    }
    
    int countAttributes (Type t, string propertyName)
    {
        var property = t.GetProperty (propertyName);
        if (property == null)
            return 0;
        return (property.GetCustomAttributes (false).Length);
    }
