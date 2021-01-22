            public void Start()
            {
                ThreadPool.QueueUserWorkItem(delegate // added
                {
                    lock (this._lock)
                    {
                        if (!this._active)
                        {
                            this._active = true;
                            this._timer.Change(TimeSpan.FromMilliseconds(500d), TimeSpan.FromMilliseconds(-1d));
                        }
                    }
                });
            }
            public void Stop()
            {
                ThreadPool.QueueUserWorkItem(delegate // added
                {
                    lock (this._lock)
                    {
                        this._active = false;
                    }
                });
            }
