    public static BaseTypeFactory
    {
        public enum Types { DerType1, DerType2, DerType3 }
        public static BaseType CreateInstance(Types type)
        { 
            switch(type)
            {
                case Types.DerType1:
                    return (BaseType) Activator.
                        CreateInstance(Type.GetType("DerType1"));
                case Types.DerType2:
                    return (BaseType) Activator.
                        CreateInstance(Type.GetType("DerType2"));
                case Types.DerType3:
                    return (BaseType) Activator.
                        CreateInstance(Type.GetType("DerType3"));
                default:
                    thrown new ArgumentException("Invalid Type specified");
            }
        }
    }
