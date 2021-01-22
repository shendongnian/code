    // class member
    private object syncObject = new object();
    
    // then, in your code...
    lock(syncObject) {
       System.Threading.Timer tmr = new System.Threading.Timer(new System.Threading.TimerCallback(Reset), null, 10, System.Threading.Timeout.Infinite);
       datarow.other_column = value;
    }
