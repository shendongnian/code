            public bool Start()
            {
                if (0 == Interlocked.CompareExchange(ref this._active, 0, 0)) // will evaluate to true if we're not started; this is a variation on the double-checked locking pattern, without the problems associated with lack of memory barriers (see http://www.cs.umd.edu/~pugh/java/memoryModel/DoubleCheckedLocking.html)
                {
                    lock (this._lock) // serialize all Start calls that are invoked on an un-started component from different threads
                    {
                        if (this._active == 0) // make sure only the first Start call gets through to actual start, 2nd part of double-checked locking pattern
                        {
                            // run component startup
                            this._timer.Change(TimeSpan.FromMilliseconds(500d), TimeSpan.FromMilliseconds(-1d));
                            Interlocked.Exchange(ref this._active, 1); // now mark the component as successfully started
                        }
                    }
                }
                return true;
            }
            public void Stop()
            {
                Interlocked.Exchange(ref this._active, 0);
            }
            private void Notify(object ignore) // this will be invoked invoked in the context of a threadpool worker thread
            {
                if (0 != Interlocked.CompareExchange(ref this._active, 0, 0)) // only handle the timer event in started components (notice the pattern is the same as in Start method except for the return value comparison)
                {
                    lock (this._lock) // protect internal state
                    {
                        if (this._active != 0)
                        {
                            var notification = this.Notification; // make a local copy
                            if (notification != null)
                            {
                                notification(this, new MyEventArgs { NotificationText = "Now is " + DateTime.Now.ToString("o") });
                            }
                            this._timer.Change(TimeSpan.FromMilliseconds(500d), TimeSpan.FromMilliseconds(-1d)); // rinse and repeat
                        }
                    }
                }
            }
            private int _active;
