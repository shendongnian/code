    public class Base
    {
         protected Base(SomeOtherType dataWrapper)
         {
             var data = dataWrapper.DerivedLogic();
             // base logic using data
         }
    }
    public class DerivedOne : Base
    {
        public DerivedOne(SomeOtherType otherType) : base(otherType)
        {
            ...
        }
    }
