    using System.Reflection; 
    public static object GetPropValue(object src, string propName)
    {
        return src.GetType().GetRuntimeProperty(propName)?.GetValue(src);
    }
