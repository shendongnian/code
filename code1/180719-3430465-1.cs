      public class ObjectWithCachedHashCode
                {
                    public object Object { get; private set; }
        
                    public int HashCode { get; private set; }
        
                    public ObjectWithCachedHashCode(object obj)
                    {
                        Object = obj;
                        HashCode = obj.GetHashCode();
                    }
                }
