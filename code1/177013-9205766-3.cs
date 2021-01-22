    public class BaseType {
       readonly int mBaseField;
       public BaseType(BaseType pSource) =>
          mBaseField = pSource.mBaseField;
       public virtual BaseType Clone() =>
          new BaseType(this);
    }
    public class SubType : BaseType {
       readonly int mSubField;
       
       public SubType(SubType pSource)
       : base(pSource) =>
          mSubField = pSource.mSubField;
       public override BaseType Clone() =>
          new SubType(this);
    }
