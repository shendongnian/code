    public static class Linker
    {
    
        //(Non-lambda version, I'm not comfortable with lambdas:)
        public static EventHandler<ValueEventArgs<bool>> Link(Publisher publisher, Control subscriber)
        {
             EventHandler<ValueEventArgs<bool>> d = delegate(object sender, ValueEventArgs<bool> e)
                 {
                      subscriber.Enabled = e.Value;
                 };
             publisher.EnabledChanged += d;
             return d;
        }
        public static void UnLink(EventHandler<ValueEventArgs<bool>> d)
        {
             publisher.EnabledChanged -= d;
        }
    }
