    [KnownType("GetKnownTypes")]
    public class StatusBase 
    {
            private static Type[] GetKnownTypes()
            {
                var types = new List<Type>();
    
                //add all your types here using reflection.
                return types.ToArray();
            }
    }
