            private async Task UnitWorkAsync()
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                await Task.Yield();
                // Blocking call.
                //
                Thread.Sleep( 2000 );
                // Async call.
                //
                await Task.Delay( 100 );
                Console.WriteLine( "UnitWorkAsync timer: " + stopwatch.ElapsedMilliseconds );
                Interlocked.Increment( ref workItemsCount );
                //Console.WriteLine( "Work items completed: " + workItemsCount );
            }
