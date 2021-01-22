    internal class CustomDataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; }
        public CustomDataReceivedEventArgs(string data) 
        {
            Data = data;
        }
        public CustomDataReceivedEventArgs(DataReceivedEventArgs source) 
        {
            Data = source.Data;
        }
    }
