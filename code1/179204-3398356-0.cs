    public WaitHandle CancellableSleep = new WaitHandle(); // publicly available
    // in your code under test use this instead of Thread.Sleep()...
    while( running ) {
        // .. work ..
        CancellableSleep.WaitOne( Interval ); // suspends thread for Interval timeout
    }
    // external code can cancel the sleep by doing:
    CancellableSleep.Set(); // trigger the handle...
