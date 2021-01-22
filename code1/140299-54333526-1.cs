 sharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
protected List<KeyValuePair<Type, PropertyInfo>> RecrusiveReflectionCompare<T>(T first, T second)
        where T : class
    {
        var differences = new List<KeyValuePair<Type, PropertyInfo>>();
        var parentType = first.GetType();
        void CompareObject(object obj1, object obj2, PropertyInfo info)
        {
            if (!obj1.Equals(obj2))
            {
                differences.Add(new KeyValuePair<Type, PropertyInfo>(parentType, info));
            }
        }
        foreach (PropertyInfo property in parentType.GetProperties())
        {
            object value1 = property.GetValue(first, null);
            object value2 = property.GetValue(second, null);
            if (property.PropertyType == typeof(string))
            {
                if (string.IsNullOrEmpty(value1 as string) != string.IsNullOrEmpty(value2 as string))
                {
                    CompareObject(value1, value2, property);
                }
            }
            else if (property.PropertyType.IsPrimitive)
            {
                CompareObject(value1, value2, property);
            }
            else
            {
                if (value1 == null && value2 == null)
                {
                    continue;
                }
                differences.Concat(RecrusiveReflectionCompare(value1, value2));
            }
        }
        return differences;
    }
