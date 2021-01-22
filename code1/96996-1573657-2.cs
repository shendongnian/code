    public class ParentObj : ICloneable
    {
        protected int myA;
        public virtual Object Clone()
        {
            ParentObj newObj = this.MemberwiseClone() as ParentObj;
            newObj.myA = this.MyA; // not required, as value type (int) is automatically already duplicated.
            return newObj;
        }
    }
    
    public class ChildObj : ParentObj
    {
        protected int myB;
        public override Object Clone()
            {
                 ChildObj newObj = base.Clone() as ChildObj;
                 newObj.myB = this.MyB; // not required, as value type (int) is automatically already duplicated
    
                 return newObj;
            }
    }
