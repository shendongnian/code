        sealed class Logger : IDisposable
        {
            private bool _disposed = false;
            public Logger()
            {
                System.IO.File.AppendAllText( @"C:\mylog.txt", "LOG STARTED" );
            }
            ~Logger()
            {
                Dispose();
            }
            public void Dispose()
            {
                if ( !_disposed )
                {
                    System.IO.File.AppendAllText( @"C:\mylog.txt", "LOG STOPPED" );
                    _disposed = true;
                }
            }
            public void WriteMessage( string msg )
            {
                System.IO.File.AppendAllText( @"C:\mylog.txt", "MESSAGE: " + msg );
            }
        }
