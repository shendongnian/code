    public static Y To<X, Y>(this X source) where X : IActiveRecord where Y: class
    {
        try
        {
            Y target = Activator.CreateInstance(typeof(Y)) as Y;
            BindingFlags memberAccess = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.SetProperty;
            PropertyInfo[] targetProperties = target.GetType().GetProperties(memberAccess);
            foreach (MemberInfo Field in targetProperties)
            {
                string name = Field.Name;
                if (Field.MemberType == MemberTypes.Property)
                {
                    PropertyInfo targetProperty = Field as PropertyInfo;
                    PropertyInfo sourceProperty = source.GetType().GetProperty(name, memberAccess);
                    if (sourceProperty == null) { continue; }
                    if (targetProperty.CanWrite && sourceProperty.CanRead)
                    {
                        object targetValue = targetProperty.GetValue(target, null);
                        object sourceValue = sourceProperty.GetValue(source, null);
                        if (sourceValue == null) { continue; }
                        if (targetProperty.PropertyType.FullName == sourceProperty.PropertyType.FullName)
                        {
                            object tempSourceValue = sourceProperty.GetValue(source, null);
                            targetProperty.SetValue(target, tempSourceValue, null);
                        }
                    }
                }
            }
            return target;
        }
        // it's important to return null if there are any errors.
        catch { return null; }
    }
    public static IList<Y> To<X, Y>(this BindingListEx<X> collection) where X : IActiveRecord where Y : class
    {
        IList<Y> returnList = new List<Y>();
        foreach (X item in collection)
            returnList.Add(item.To<X,Y>());
        return returnList;
    }
