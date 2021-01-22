    public static class Linker
    {
    
        //(Non-lambda version, I'm not comfortable with lambdas:)
        public static Delegate Link(Publisher publisher, Control subscriber)
        {
             Delegate d = delegate(object sender, ValueEventArgs<bool> e)
                 {
                      subscriber.Enabled = e.Value;
                 };
             publisher.EnabledChanged += d;
             return d;
        }
        public static void UnLink(Delegate d)
        {
             publisher.EnabledChanged -= d;
        }
    }
