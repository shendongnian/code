    public abstract class BaseObject<T> where T : BaseObject<T>
    {
        public abstract T Clone();
    }
    public class DerivedObject : BaseObject<DerivedObject>
    {
        public override DerivedObject Clone()
        {
             // ...
        }
    }
