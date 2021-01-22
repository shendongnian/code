    public class Foo
    {
        public event EventHandler<EventArgs> Bar;
        public void OnBar()
        {
            Bar.InvokeAsync(this, EventArgs.Empty);
        }
    }
