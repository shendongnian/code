    public class BaseObject
    {
        protected virtual String getMood()
        {
            return "Base mood";
        }
        //...
    }
    public class DerivedObject: BaseObject
    {
        protected override String getMood()
        {
            return "Derived mood";
        }
        //...
    }
