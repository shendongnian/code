    public abstract class Foo
    {
        protected abstract void DoBar();
        public void Bar()
        {
            // do stuff that has to happen regardless of how 
            // DoBar() has been implemented in the derived
            // class
            DoBar();
            // do other stuff
        }
    }
