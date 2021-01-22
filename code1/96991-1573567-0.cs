    [Serializable]
    public class ParentObj: ICloneable
    {
        private int myA;
        [NonSerialized]
        private object somethingInternal;
    
        public virtual object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            object clone = formatter.Deserialize(ms);
            return clone;
        }
    }
    
    [Serializable]
    public class ChildObj: ParentObj
    {
        private int myB;
    
        // No need to override clone, as it will still serialize the current object, including the new myB field
    }
