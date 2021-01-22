        public event EventHandler WorkComplete;
        private void StartClick(object sender, EventArgs e)
        {
            //hook a complete event
            this.WorkComplete += new EventHandler(OnWorkComplete);
            //do start code
            //run the PerformSynchronousActionUsingWaitHandle process in a thread
            Thread thread = new Thread(new ThreadStart(PerformSynchronousActionUsingWaitHandle));
            thread.Start();
        }
        private void OnWorkComplete(object sender, EventArgs e)
        {
            //cross thread
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(OnWorkComplete), new object[] { sender, e });
                return;
            }
     
            //un hook
            this.WorkComplete -= new EventHandler(OnWorkComplete);
            //do complete code
        }
        private void PerformSynchronousActionUsingWaitHandle()
        {
            Thread.Sleep(1000);
            if (WorkComplete != null)
            {
                WorkComplete(this, EventArgs.Empty);
            }
        }
