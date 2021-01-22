    public class BaseClass
    {
        // This is the Update that class instances will use, it's never overridden by a subclass
        public void Update()
        {
            if(condition);
            // etc... base class code that will always run
            UpdateEx(); // ensure subclass Update() functionality is run
        }
        protected virtual void UpdateEx()
        {
            // does nothing unless sub-class overrides
        }
    }
