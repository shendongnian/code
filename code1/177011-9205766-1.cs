    public class BaseType
    {
       private readonly int mBaseField;
       public BaseType(BaseType pSource)
       {
          mBaseField = pSource.mBaseField;
       }
       public virtual BaseType Clone()
       {
          return new BaseType(this);
       }
    }
    public class SubType : BaseType
    {
       private readonly int mSubField;
       
       public SubType(SubType pSource)
          : base(pSource)
       {
          mSubField = pSource.mSubField;
       }
       public override BaseType Clone()
       {
          return new SubType(this);
       }
    }
    
