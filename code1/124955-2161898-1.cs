    static class Extensions
    {
     public static void DoStuffAndDisposeElements<T> ( this List<T> list, Action<T> action )
     {
            list.ForEach ( x => { action ( x );
                   IDisposable disposable = (x as IDisposable);
                   if ( disposable != null )
                      disposable.Dispose ();
     
            } );
     }
    
    }
