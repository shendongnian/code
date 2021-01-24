    public class Base
    {
         protected Base(SomeType data)
         {
             // base logic using data
         }
    }
    public class DerivedOne : Base
    {
        public DerivedOne(int some, string data) : base(DerivedLogic(some, data))
        {
            ...
        }
        private static SomeType DerivedLogic(int some, string data) => ...
    }
    public class DerivedTwo : Base
    {
        public DerivedTwo (string moreStuff) : base(DerivedLogic(moreStuff))
        {
            ...
        }
        private static SomeType DerivedLogic(string moreStuff) => ...
    }
