    public class Program
    {
        static async Task Main(string[] args)
        {
            RestartTaskDemo restartTaskDemo = new RestartTaskDemo();
            Task[] tasks = { restartTaskDemo.RestartAsync( 1000 ), restartTaskDemo.RestartAsync( 1000 ), restartTaskDemo.RestartAsync( 1000 ) };
            await Task.WhenAll( tasks );
            Console.ReadLine();
        }
    }
    public class RestartTaskDemo
    {
        private int Counter = 0;
        private TaskEntry PreviousTask = new TaskEntry( Task.CompletedTask, new CancellationTokenSource() );
        public async Task RestartAsync( int delay )
        {            
            TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            TaskEntry previousTaskEntry = Interlocked.Exchange( ref PreviousTask, new TaskEntry( taskCompletionSource.Task, cancellationTokenSource ) );
            previousTaskEntry.CancellationTokenSource.Cancel();
            await previousTaskEntry.Task.ContinueWith( Continue );
            async Task Continue( Task previousTask )
            {
                try
                {
                    await DoworkAsync( delay, cancellationTokenSource.Token );
                    taskCompletionSource.TrySetResult( true );
                }
                catch( TaskCanceledException )
                {
                    taskCompletionSource.TrySetCanceled();
                }
            }            
        }
        private async Task DoworkAsync( int delay, CancellationToken cancellationToken )
        {
            int count = Interlocked.Increment( ref Counter );
            Console.WriteLine( $"Task {count} started." );
            try
            {
                await Task.Delay( delay, cancellationToken );
                Console.WriteLine( $"Task {count} finished." );
            }
            catch( TaskCanceledException )
            {
                Console.WriteLine( $"Task {count} cancelled." );
                throw;
            }
        }
        private class TaskEntry
        {
            public Task Task { get; }
            public CancellationTokenSource CancellationTokenSource { get; }
            public TaskEntry( Task task, CancellationTokenSource cancellationTokenSource )
            {
                Task = task;
                CancellationTokenSource = cancellationTokenSource;
            }
        }
    }
