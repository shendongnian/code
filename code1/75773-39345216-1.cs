    using System.Linq;
    using System.Reflection;
    
    public static object GetPropValue(object source, string propertyName)
    {
        var property = source.GetType().GetRuntimeProperties().FirstOrDefault(p => string.Equals(p.Name, propertyName, StringComparison.OrdinalIgnoreCase));
        if(property != null)
        {
            return property.GetValue(source);
        }
        return null;
    }
