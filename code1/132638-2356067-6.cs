    private static void ExecuteOnUIThread( Control control, Action action )
    {
        if ( control.InvokeRequired )
        {
           control.Invoke( action );
        }
        else
        {
           action();
        }
     }
