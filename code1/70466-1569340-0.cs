    [Export(typeof(IDispatcher))]
    public class ApplicationDispatcher : IDispatcher
    {
        public void Dispatch( Delegate method, params object[] args )
        { UnderlyingDispatcher.BeginInvoke(method, args); }
        // -----
        Dispatcher UnderlyingDispatcher
        {
            get
            {
                if( App.Current == null )
                    throw new InvalidOperationException("You must call this method from within a running WPF application!");
                if( App.Current.Dispatcher == null )
                    throw new InvalidOperationException("You must call this method from within a running WPF application with an active dispatcher!");
                return App.Current.Dispatcher;
            }
        }
    }
