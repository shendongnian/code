     System.Threading.Thread t = new System.Threading.Thread(() =>
        {
            try
            {
                ...
                //this exception will not be catched by 
                //Application.DispatcherUnhandledException
                throw new Exception("huh..");
                ...
            }
            catch (Exception ex)
            {
                //But we can handle it in the throwing thread
                //and pass it to the main thread wehre Application.
                //DispatcherUnhandledException can handle it
                System.Windows.Application.Current.Dispatcher.Invoke(
                    System.Windows.Threading.DispatcherPriority.Normal,
                    new Action<Exception>((exc) =>
                        {
                          throw new Exception("Exception from another Thread", exc);
                        }), ex);
            }
        });
