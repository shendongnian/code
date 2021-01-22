    public class MyEventArgs : EventArgs
    {
        public bool Handled { get; set; }
    }
    public class SomeClass
    {
        public event EventHandler<MyEventArgs> SomeEvent;
        protected virtual void OnSomeEvent(MyEventArgs e)
        {
            var listeners = SomeEvent.GetInvocationList();
            foreach (var listener in listeners)
            {
                if (e.Handled) break;
                ((EventHandler<MyEventArgs>)listener).Invoke(this, e);
            }
        }
    }
