    public void insertAllFromVariable(GameObject target, List<Type> types, string propertyName)
            {
                var components = target.GetComponents<Component>();
                foreach (var component in components)
                {
                    if (types.Contains(component.GetType()))
                    {
                        PropertyInfo property = component.GetType().GetProperty(propertyName);
                        object theRealObject = property.GetValue(component);
    
                        PropertyInfo[] propertysProperties = theRealObject.GetType().GetProperties().Where(t => t.GetCustomAttributes<ListableAttribute>().Count() > 0);
                        foreach (PropertyInfo p in propertysProperties)
                        {
                            Debug.Log("VALUE: " + p.GetValue(theRealObject));
