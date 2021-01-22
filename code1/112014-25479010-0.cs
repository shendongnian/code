        // The flag
        private bool _isClosing = false;
        // Action that avoids validation
        protected override void OnClosing(CancelEventArgs e) {
            _isClosing = true;
            base.OnClosing(e);
        }
        // Validated event handler
        private void txtControlToValidate_Validated(object sender, EventArgs e) {           
            _isClosing = false;
            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        // Do validation on complete so you'll remain on same thread
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (!_isClosing)
                DoValidationHere();
        }
        // Give a delay, I'm not sure this is necessary cause I tried to remove the Thread.Sleep and it was still working fine. 
        void worker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.Sleep(100);
        }
