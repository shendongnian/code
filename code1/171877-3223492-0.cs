    public class Foo
    {
        public SomeHandler OnBar;
        public void Bar()
        {
            if (OnBar != null)
            {
                OnBar(this, EventArgs.Empty);
            }
            BarImpl();
        }
        protected virtual void BarImpl()
        {
        }
    }
