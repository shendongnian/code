    public sealed class QueuedLock {
        private object innerLock = new object();
        private volatile int ticketsCount = 0;
        private volatile int ticketToRide = 1;
        ThreadLocal<int> reenter = new ThreadLocal<int>();
        public void Enter() {
            reenter.Value++;
            if ( reenter.Value > 1 ) 
                return;
            int myTicket = Interlocked.Increment( ref ticketsCount );
            Monitor.Enter( innerLock );
            while ( true ) {
                if ( myTicket == ticketToRide ) {
                    return;
                } else {
                    Monitor.Wait( innerLock );
                }
            }
        }
        public void Exit() {
            if ( reenter.Value > 0 ) 
                reenter.Value--;
            if ( reenter.Value > 0 ) 
                return;
            Interlocked.Increment( ref ticketToRide );
            Monitor.PulseAll( innerLock );
            Monitor.Exit( innerLock );
        }
    }
