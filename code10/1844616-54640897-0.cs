    class DontGarbageCollect
    {
        static timer;
        
        public void ShowTimer() {
            // Store timer in this.timer to prevent garbage collection
            this.timer = new System.Threading.Timer(a =>
                {
                   //Stuff to perform after 10 seconds
                }, null, 10000, 0);
        }
    }
