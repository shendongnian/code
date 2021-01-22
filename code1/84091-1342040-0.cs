    class MyBackgroundWorker :BackgroundWorker {
        public MyBackgroundWorker() {
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
        }
        protected override void OnDoWork( DoWorkEventArgs e ) {
            var thread = Thread.CurrentThread;
            using( var cancelTimeout = new System.Threading.Timer( o => CancelAsync(), null, TimeSpan.FromMinutes( 1 ), TimeSpan.Zero ) )
            using( var abortTimeout = new System.Threading.Timer( o => thread.Abort(), null, TimeSpan.FromMinutes( 2 ), TimeSpan.Zero ) ) {
                for( int i = 0; i <= 100; i += 20 ) {
                    ReportProgress( i );
                    if( CancellationPending ) {
                        e.Cancel = true;
                        return;
                    }
                    Thread.Sleep( 1000 ); //do work
                }
                e.Result = "My Result";  //report result
                base.OnDoWork( e );
            }
        }
    }
