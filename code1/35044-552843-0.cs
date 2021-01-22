    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    
    static class Program
    {
        static void Main()
        {
            ...
        }
        public static void SetParent<T>(T root)
        {
            foreach (PropertyInfo prop in typeof(T).GetProperties
                (BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanRead) continue;
    
                Type listType = null;
                foreach (Type interfaceType in prop.PropertyType.GetInterfaces())
                {
                    if (interfaceType.IsGenericType &&
                        interfaceType.GetGenericTypeDefinition() == typeof(IList<>))
                    { // IList<T> detected
                        listType = interfaceType.GetGenericArguments()[0];
                    }
                }
    
                List<PropertyInfo> propsToSet = new List<PropertyInfo>();
                foreach (PropertyInfo childProp in (listType ?? prop.PropertyType).GetProperties(
                    BindingFlags.Public | BindingFlags.Instance))
                {
                    if (childProp.PropertyType == typeof(T)) propsToSet.Add(childProp);
                }
    
                if(propsToSet.Count == 0) continue; // nothing to do
                if (listType == null)
                {
                    object child = prop.GetValue(root, null);
                    if (child == null) continue;
                    foreach (PropertyInfo childProp in propsToSet)
                    {
                        childProp.SetValue(child, root, null);
                    }
                }
                else
                {
                    IList list = (IList)prop.GetValue(root, null);
                    foreach (object child in list)
                    {
                        if (child == null) continue;
                        foreach (PropertyInfo childProp in propsToSet)
                        {
                            childProp.SetValue(child, root, null);
                        }
                    }
                }
            }
        }
    }
