    public ResultExport
    {
        private AnonymousPipeServerStream WriteStream = null;
        public Stream Export()
        {
            //
            // We'll fire off the database query in a background
            // thread.  It will write data to one end of the pipe.  We'll return the reader
            // end of that pipe to our caller.
            //
            WriteStream = new AnonymousPipeServerStream( PipeDirection.Out );
            AnonymousPipeClientStream reader = new AnonymousPipeClientStream( PipeDirection.In, WriteStream.ClientSafePipeHandle );
            //
            // Call Execute() in a background thread.
            //
            Task.Factory.StartNew( () => Execute() );
            //
            // While Execute() is filling the pipe with data,
            // return the reader end of the pipe to our caller.
            //
            return reader;
        }
        private void Execute ()
        {
            //
            // WriteStream should only by populated by Export()
            //
            if( WriteStream != null )
            {
                using ( StreamWriter sw = new StreamWriter( WriteStream, Encoding.UTF8, 4096 ) )
                {
                    //
                    // Shove data into the StreamWriter as we get it from the database
                    //
                    foreach ( string line in ExportCore() )
                    {
                        // Each line is a comma-delimited set of values
                        sw.WriteLine( line );
                    }
                }
            }
        }
    }
