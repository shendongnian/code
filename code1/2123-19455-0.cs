    [TestClass]
    public class When_type_inherits_MyObject
    {
        private readonly List<Type> _types = new List<Type>();
    
        public When_type_inherits_MyObject()
        {
            // lets find all types that inherit from MyObject, directly or indirectly
            foreach(Type type in typeof(MyObject).Assembly.GetTypes())
            {
                if(type.IsClass && typeof(MyObject).IsAssignableFrom(type))
                {
                    _types.Add(type);
                }
            }
        }
    
        [TestMethod]
        public void Properties_have_XmlElement_attribute
        {
            foreach(Type type in _types)
            {
                foreach(PropertyInfo property in type.GetProperties())
                {
                    object[] attribs = property.GetCustomAttributes(typeof(XmlElementAttribute), false);
                    Assert.IsTrue(attribs.Count > 0, "Missing XmlElementAttribute on property " + property.Name + " in type " + type.FullName);
                }
            }
        }
    }
