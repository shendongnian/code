    public class Parent
    {
        public void OnLoad()
        {
            // Important load stuff goes here
            OnLoadInternal();
        }
        protected virtual void OnLoadInternal()
        {
            // No implmentation in parent; child can override if needed
        }
    }
    public class Child : Parent
    {
        protected override void OnLoadInternal()
        {
            base.OnLoadInternal();
            // Important load stuff, but can't break parent by omitting base call
        }
    }
