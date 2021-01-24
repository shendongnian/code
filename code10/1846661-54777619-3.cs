    public class ProgressEventArgs : EventArgs
    {
        private int _taskId;
        private int _percent;
        private string _message;
        public int TaskId => _taskId;
        public int Percent => _percent;
        public string Message => _message;
        public ProgressEventArgs(int taskId, int percent, string message)
        {
            _taskId = taskId;
            _percent = percent;
            _message = message;
        }
    }
