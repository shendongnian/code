      public class ObjectWithCachedHashCode : IEquatable<ObjectWithCachedHashCode>
        {
            private int _cachedHashCode;
            public object Object { get; private set; }
            public ObjectWithCachedHashCode(object obj)
            {
                Object = obj;
                _cachedHashCode = obj.GetHashCode();
            }
            public override int GetHashCode()
            {
                return _cachedHashCode;
            }
            public bool Equals(ObjectWithCachedHashCode other)
            {
                return other!=null && Object.Equals(other.Object);
            }
            public override bool Equals(object other)
            {
                return Equals(other as ObjectWithCachedHashCode);
            }
           
        }
