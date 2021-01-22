    public static void WriteLine( String format, params object[] args )
    {
        if ( TheInstance != null )
        {
            TheInstance.TheCreatingThreadDispatcher.BeginInvoke(  Instance.WriteLine_Signal, format, args );
        }
    }
