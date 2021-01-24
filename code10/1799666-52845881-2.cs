        private System.Threading.Thread Thread_OutputHandle = null;
        private void shellStream_DataReceived(object sender, Renci.SshNet.Common.ShellDataEventArgs e)
        {
            if (Thread_OutputHandle == null)
            {
                
                Thread_OutputHandle = new System.Threading.Thread(new System.Threading.ThreadStart(readOutput));
                Thread_OutputHandle.Start();
            }
            else if (Thread_OutputHandle.ThreadState == System.Threading.ThreadState.Stopped)
            {
                Thread_OutputHandle.Abort();
                Thread_OutputHandle = new System.Threading.Thread(new System.Threading.ThreadStart(readOutput));
                Thread_OutputHandle.Start();
            }            
        }
