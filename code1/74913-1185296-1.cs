    [DataContract]
    public class AppInfo
    {
        private int _processID;
        private string _processName;
    
        [DataMember]
        public int ProcessID
        {
            get { return _processID; }
            set { _processID = value; }
        }
    
        [DataMember]
        public string ProcessName
        {
            get { return _processName; }
            set { _processName= value; }
        }
    }
