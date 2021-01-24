    Task.Run( async ( ) =>
            {
                wToken.ThrowIfCancellationRequested( );
                connectionPool.PollEvents( );
                await Task.Delay( configLoader.config.connectionPollDelay, wToken );
            }, wToken ).ContinueWith( task =>
            {
                if( task.IsFaulted )
                {
                    // Inspect the exception property of the task
                    // to view the exception / exceptions.
                    Console.WriteLine( task.Exception?.InnerException );
                }
            }, wToken );
