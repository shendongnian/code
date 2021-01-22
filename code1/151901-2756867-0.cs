    public class Synchronizer {
        private List<Action> workers = new List<Action>();
        public List<Action> Workers { get { return workers; } }
    
        public void Run( Action callBackOnDone ) {
            var workers Workers.ToArray();
            object syncRoot = new object();
            int counter = workers.Length;
            foreach( var worker in workers ) {
                ThreadPool.QueueUserWorkItem( ()=> {
                    try { worker(); }
                    finally {
                        lock(syncRoot) {
                             counter--;
                             if ( counter <= 0 ) {
                                 callBackOnDone();
                             }
                        }
                    }
                } );
            }
        }
    }
