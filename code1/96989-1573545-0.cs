    public class ParentObj : ICloneable
    {
        public virtual Object Clone()
        {
            var obj = new ParentObj();
            CopyObject(this, obj);
        }
        protected virtual CopyObject(ParentObj source, ParentObj dest)
        {
            dest.myA = source.myA;
        }
    }
    public class ChildObj : ParentObj
    {
        public override Object Clone()
        {
            var obj = new ChildObj();
            CopyObject(this, obj);
        }
        public override CopyObject(ChildObj source, ParentObj dest)
        {
            base.CopyObject(source, dest)
            dest.myB = source.myB;
        }
    }
