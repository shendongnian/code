    using( var mutex = new Mutex( false, AppGuid ) )
    {
        try
        {
            try
            {
                if( !mutex.WaitOne( 0, false ) )
                {
                    MessageBox.Show( "Another instance is already running." );
                    return;
                }
            }
            catch( AbandonedMutexException )
            {
                // Log the fact the mutex was abandoned in another process,
                // it will still get aquired
            }
            Application.Run(new Form1());
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
