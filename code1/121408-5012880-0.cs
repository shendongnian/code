    //My base class
    //I add a type to my base class use that in the static method to check the type of the caller.
    public class EnhancedAttribute<TSelfReferenceType> : Attribute
    {
        public static bool IsDefinedOn(Type containerType, string propertyName)
        {
            var propInfo = containerType.GetProperty(propertyName);
            if (propInfo == null)
            {
                throw new InvalidOperationException("Unable to identify Property of name: " + propertyName + " in type: " + containerType.Name);
            }
            return propInfo.GetCustomAttributes(typeof(TSelfReferenceType), true) > 0;
    }
