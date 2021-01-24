    public class MyFactory
    {
        Type baseType = typeof(MyBaseType);
        IDictionary<string, Type> typeMap = new Dictionary<string, Type>() {}
        public void RegisterType(string typeName, Type type) 
        {
            if (!(type == baseType || baseType.IsAssignableFrom(type)) throw new ArgumentException(nameof(type));
            typeMap.Add(typeName, type);    
        }
    }
 
