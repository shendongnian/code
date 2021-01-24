    public class Processing
    {
        public Results ProcessData(IProgress<string> statusReporter, CancellationToken cancellationToken)
        {
            foreach (var record in dataCases)
            {
                // Doing other things here like updating
                
                // Update the status:
                statusReporter.OnReport(record.RequestReference);
                
                // Stop if the task has been cancelled:
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
    
    public partial class ProcessingUI : Form
    {
        private void start_Click(object sender, EventArgs e)
        {
            StartProcessingTask();
        }
    
        private void StartProcessingTask()
        {
            if (_isRunning)
                return;
            
            _isRunning = true;
            _taskToken = new CancellationTokenSource();
            
            CancellationToken cancellationToken = _taskToken.Token;
            IProgress<string> statusReporter = new Progress<string>(UpdateStatus);
    
            Task.Run(() =>
            {
                while (_isRunning)
                {
                    var data = _processing.ProcessData(lblCounter, cancellationToken);
                    if (data.Success)
                    {
                        _isRunning = false;
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }
            });
        }
    
        private void UpdateStatus(string message)
        {
            lblCounter.Text = message;    
        }
    }
