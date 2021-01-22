    class Test : Form
    {
        private BackgroundWorker MyWorker = new BackgroundWorker();
    
        public Test() {
            MyWorker.DoWork += new DoWorkEventHandler(MyWorker_DoWork);
        }
    
        void MyWorker_DoWork(object sender, DoWorkEventArgs e) {
            for (int i = 0; i < 100; i++) {
                //Do stuff here
                System.Threading.Thread.Sleep((new Random()).Next(0, 1000));  //WARN: Artificial latency here
                if (MyWorker.CancellationPending) { return; } //Bail out if MyWorker is cancelled
            }
        }
    
        public void CancelWorker() {
            if (MyWorker != null && MyWorker.IsBusy) {
                MyWorker.CancelAsync();
                System.Threading.ThreadStart WaitThread = new System.Threading.ThreadStart(delegate() {
                    while (MyWorker.IsBusy) {
                        System.Threading.Thread.Sleep(100);
                    }
                });
                WaitThread.BeginInvoke(a => {
                    Invoke((MethodInvoker)delegate() { //Invoke your StuffAfterCancellation call back onto the UI thread
                        StuffAfterCancellation();
                    });
                }, null);
            } else {
                StuffAfterCancellation();
            }
        }
    
        private void StuffAfterCancellation() {
            //Things to do after MyWorker is cancelled
        }
    }
