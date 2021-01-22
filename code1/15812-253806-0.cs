    public class Foo
    {
        public event EventHandler Click;
    
        protected virtual void OnClick(EventArgs e)
        {
            var click = Click;
            if (click != null)
                click(this, e);
        }
    }
