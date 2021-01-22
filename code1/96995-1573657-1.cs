    public class ParentObj : ICloneable
    {
        protected int myA;
        public virtual Object Clone()
        {
            ParentObj newObj = this.MemberwiseClone() as ParentObj;
            newObj.myA = this.MyA;
            return newObj;
        }
    }
    
    public class ChildObj : ParentObj
    {
        protected int myB;
        public override Object Clone()
            {
                 ChildObj newObj = this.base.Clone() as ChildObj;
                 newObj.myB = this.MyB;
    
                 return newObj;
            }
    }
