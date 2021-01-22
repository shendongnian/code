    internal class CustomDataReceivedEventArgs : EventArgs
    {
        public string Data { get; set; }
        public CustomDataReceivedEventArgs(string _Data) 
        {
            Data = Data;
        }
        public CustomDataReceivedEventArgs(DataReceivedEventArgs Source) 
        {
            Data = Source.Data;
        }
    }
