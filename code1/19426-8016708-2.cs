        public class TypeInfo
        {
            public TypeInfo()
            {
                ExtensionMethods = new List<MethodInfo>();
            }
            public List<ConstructorInfo> Constructors { get; set; }
            public List<FieldInfo> Fields { get; set; }
            public List<PropertyInfo> Properties { get; set; }
            public List<MethodInfo> Methods { get; set; }
            public List<MethodInfo> ExtensionMethods { get; set; }
        }
