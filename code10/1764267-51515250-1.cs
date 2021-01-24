    //The progress class
    class FileProgress
    {
        public string FileName{get;set;}
        public int Progress{get;set;}
        public string Message{get;set;}
        public FileProgress(string fileName,int progress,string message)
        {
            FileName=filename;
            Progress=progress;
            Message=message;
        }
    }
    //In the form itself
    private void ReportStart()
    {
        ProcessProgress.IsIndeterminate = true;
        ProcessProgress.Visibility = Visibility.Visible;
    }
    private void ReportEnd()
    {
        ProcessProgress.IsIndeterminate = false;
        ProcessProgress.Value = ProcessProgress.Maximum;
    }
    private void ReportProgress(FileProgress progress)
    {
        ProcessProgress.Value =progress.Progress;        
        PanelStatus.Text = $"Working on {progress.FileName} : {progress.Message}";
    }
