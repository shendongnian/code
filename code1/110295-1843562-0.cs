    /// <summary>
    /// Try to parse an XElement into a matching type. Type must have an Id
    /// </summary>
    /// <returns>newly created type with Id and other properties filled</returns>
    public static T ToParsedObject<T>(this XElement xmlElement)
        where T : new()
    {
        T item = new T();
        Type type = typeof(T);
    
        // you can use GetProperties to go through all of them dynamically
        PropertyInfo prop = type.GetProperty("Id");
        prop.SetValue(item, xmlElement.Element(
            XName.Get(type.Name + "Id")),         // creates UserId or CustomerId etc
            null);
        return item;
    }
