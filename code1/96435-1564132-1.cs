    public class DataEventArgs : EventArgs
    {
        public string Data{get;set;}
        
        public DataEventArgs(string s)
        {
            Data = s;
        }
    }
