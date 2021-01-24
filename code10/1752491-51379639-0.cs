    [KnownType("GetDerivedTypes")]
    [DataContract]
    public abstract class ClassA         \\This is referenced in B
    {
        static Type[] GetDerivedTypes()
        { 
            return DerivedTypes.ToArray();  
        }
        public static List<Type> DerivedTypes = new List<Type>();
    }
