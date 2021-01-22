    public class Program
    {
        private volatile bool AbortOperation;
        Func<bool> AbortOperationDelegate;
        FinishProcessDelegate finishDelegate;
        UpdateGUIDelegate updateGUIDelegate;
    
        private delegate void UpdateGUIDelegate(int progress, object message);
        private delegate void FinishProcessDelegate();
    
        private void cmdBegin_Click(...)
        {
            // Create finish delegate, for determining when the thread is done.
            finishDelegate = new FinishProcessDelegate(ProcessFinished);
            // A delegate for updating the GUI.
            updateGUIDelegate = new UpdateGUIDelegate(UpdateGUI);
            // Create a delegate function for abortion.
            AbortOperationDelegate = () => AbortOperation;
        
            Thread BackgroundThread = new Thread(new ThreadStart(StartProcess));            
            // Force single apartment state. Required by ArcGIS.
            BackgroundThread.SetApartmentState(ApartmentState.STA);
            BackgroundThread.Start();
        }
    
        private void StartProcess()
        {    
            // Update GUI.
            updateGUIDelegate(0, "Beginning process...");
            
            // Create object.
            Converter converter = new Converter(AbortOperationDelegate);
            // Parse the GUI update method to the converter, so it can update the GUI from within the converter. 
            converter.Progress += new ProcessEventHandler(UpdateGUI);
            // Begin converting.
            converter.Execute();
            
            // Tell the main thread, that the process has finished.
            FinishProcessDelegate finishDelegate = new FinishProcessDelegate(ProcessFinished);
            Invoke(finishDelegate);
        
            // Update GUI.
            updateGUIDelegate(100, "Process has finished.");
        }
    
        private void cmdAbort_Click(...)
        {
            AbortOperation = true;
        }
    
        private void ProcessFinished()
        {
            // Post processing.
        }
    
        private void UpdateGUI(int progress, object message)
        {
            // If the call has been placed at the local thread, call it on the main thread.
            if (this.pgStatus.InvokeRequired)
            {
                UpdateGUIDelegate guidelegate = new UpdateGUIDelegate(UpdateGUI);
                this.Invoke(guidelegate, new object[] { progress, message });
            }
            else
            {
                // The call was made on the main thread, update the GUI.
                pgStatus.Value = progress;
                lblStatus.Text = (string)message;	
            }
        }
    }
    
    public class Converter
    {
        private Func<bool> AbortOperation { get; set;}
        
        public Converter(Func<bool> abortOperation)
        {
            AbortOperation = abortOperation;
        }
        
        public void Execute()
        {
            // Calculations using ArcGIS are done here.
            while(...) // Insert your own criteria here.
            {
                // Update GUI, and replace the '...' with the progress.
                OnProgressChange(new ProgressEventArgs(..., "Still working..."));
            
                // Check for abortion at anytime here...
                if(AbortOperation)
                {
                    return;
                }
            }
        }
        
        public event ProgressEventHandler Progress;
        private virtual void OnProgressChange(ProgressEventArgs e)
        {
            var p = Progress;
            if (p != null)
            {
    	        // Invoke the delegate. 
         	p(e.Progress, e.Message);
            }
        }    
    }
    
    public class ProgressEventArgs : EventArgs
    {
        public int Progress { get; set; }
        public string Message { get; set; }
        public ProgressEventArgs(int _progress, string _message)
        {
            Progress = _progress;
            Message = _message;
        }
    }
    
    public delegate void ProgressEventHandler(int percentProgress, object userState);
