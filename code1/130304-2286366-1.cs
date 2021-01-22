        public Thread Thread {get;set;}        
        private void PleasWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            // do not allow closing of the form while thread is running
            if (this.Thread.IsAlive)
                e.Cancel = true;
        }
        public void JoinAndClose(){
            // this is a method that allows closing by waiting for the thread to finish
            this.Thread.Join();
            Close();
        }
