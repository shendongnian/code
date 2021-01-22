    public class TestClass<T>
    {
        public void GetIDForPassedInObject(T obj)
        {
            PropertyInfo[] properties =
                obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);            
            PropertyInfo IdProperty = (from PropertyInfo property in properties
                               where property.GetCustomAttributes(typeof(Identifier), true).Length > 0
                               select property).First();
             if(null == IdProperty)
                 throw new ArgumentException("obj does not have Identifier.");
             Object propValue = IdProperty.GetValue(entity, null)
        }
    }
