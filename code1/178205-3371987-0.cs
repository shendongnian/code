    public struct MyStruct : ISerializable
        {
            #region ISerializable Members
    
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                throw new NotImplementedException();
            }
    
            #endregion
    
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
    
            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }
    
            public static bool operator ==(MyStruct m1, MyStruct m2)
            {
                return true;
            }
    
            public static bool operator !=(MyStruct m1, MyStruct m2)
            {
                return false;
            }
        }
