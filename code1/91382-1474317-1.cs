    public class FooOne : FooBase
    {
        public override void Bar()
        {
            base.Bar(); // Use base implementation.
            // Do specialized stuff.
        }
    }
    public class FooTwo : FooBase
    {
        public override void Bar()
        {
            // Do other specialized stuff.
            base.Bar(); // Use base implementation.
            // Do more specialized stuff.
        }
    }
    // This class cannot use the base implementation from FooBase because
    // of inheriting from OtherClass but it can still implement IFoo.
    public class FooThree : OtherClass, IFoo
    {
        public virtual void Bar()
        {
            // Do stuff.
        }
    }
