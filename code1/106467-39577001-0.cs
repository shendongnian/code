    using System.Threading; // used for backgroundworker
    using System.Diagnostics; // used for file information
    private static IDictionary<string, string> fileModifiedTable = new Dictionary<string, string>(); // used to keep track of our changed events
    private void fswFileWatch_Changed( object sender, FileSystemEventArgs e )
        {
            try
            {
               //check if we already have this value in our dictionary.
                if ( fileModifiedTable.TryGetValue( e.FullPath, out sEmpty ) )
                {              
                    //compare timestamps      
                    if ( fileModifiedTable[ e.FullPath ] != File.GetLastWriteTime( e.FullPath ).ToString() )
                    {        
                        //lock the table                
                        lock ( fileModifiedTable )
                        {
                            //make sure our file is still valid
                            if ( File.Exists( e.FullPath ) )
                            {                               
                                // create a new background worker to do our task while the main thread stays awake. Also give it do work and work completed handlers
                                BackgroundWorker newThreadWork = new BackgroundWorker();
                                newThreadWork.DoWork += new DoWorkEventHandler( bgwNewThread_DoWork );
                                newThreadWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler( bgwNewThread_RunWorkerCompleted );
                                // capture the path
                                string eventFilePath = e.FullPath;
                                List<object> arguments = new List<object>();
                                // add arguments to pass to the background worker
                                arguments.Add( eventFilePath );
                                arguments.Add( newEvent.File_Modified );
                                // start the new thread with the arguments
                                newThreadWork.RunWorkerAsync( arguments );
                               
                                fileModifiedTable[ e.FullPath ] = File.GetLastWriteTime( e.FullPath ).ToString(); //update the modified table with the new timestamp of the file.
                                FILE_MODIFIED_FLAG.WaitOne(); // wait for the modified thread to complete before firing the next thread in the event multiple threads are being worked on.
                            }
                        }
                    }
                }
            }
            catch ( IOException IOExcept )
            {
                //catch any errors
                postError( IOExcept, "fswFileWatch_Changed" );
            }
        }
