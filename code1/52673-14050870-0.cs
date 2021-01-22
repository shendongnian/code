        private static Mutex _mutex;
        private static bool IsSingleInstance()
        {
            _mutex = new Mutex(false, _mutexName);
            // keep the mutex reference alive until the normal 
            //termination of the program
            GC.KeepAlive(_mutex);
            try
            {
                return _mutex.WaitOne(0, false);
            }
            catch (AbandonedMutexException)
            {
                // if one thread acquires a Mutex object 
                //that another thread has abandoned 
                //by exiting without releasing it
                _mutex.ReleaseMutex();
                return _mutex.WaitOne(0, false);
            }
        }
        public Form1()
        {
            if (!isSingleInstance())
            {
                MessageBox.Show("Instance already running");
                this.Close();
                return;
            }
            //program body here
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mutex != null)
            {
                _mutex.ReleaseMutex();
            }
        }    
