    public static PropertyInfo GetPrimaryKey(this Type entityType) {
        foreach (PropertyInfo property in entityType.GetProperties()) {
            if (property.IsPrimaryKey()) {
                if (property.PropertyType != typeof (int)) {
                    throw new ApplicationException(string.Format("Primary key, '{0}', of type '{1}' is not int", property.Name, entityType));
                }
                return property;
            }
        }
        throw new ApplicationException(string.Format("No primary key defined for type {0}", entityType.Name));
    } 
    public static TAttribute GetAttributeOf<TAttribute>(this PropertyInfo propertyInfo) {
        object[] attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true);
        if (attributes.Length == 0)
            return default(TAttribute);
        return (TAttribute)attributes[0];
    }
    public static bool IsPrimaryKey(this PropertyInfo propertyInfo) {
        var columnAttribute = propertyInfo.GetAttributeOf<ColumnAttribute>();
        if (columnAttribute == null) return false;
        return columnAttribute.IsPrimaryKey;
    }
