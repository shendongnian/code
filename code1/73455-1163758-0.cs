    class BaseClass
    {
        public void X()
        {
            // Some code here
            Y();
        }
        public virtual void Y()
        {
            // Some code here
        }
    }
    class ChildClass : BaseClass
    {
        public override void Y()
        {
            // Some code here
        }
    }
