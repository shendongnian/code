    public class Logging
    {
        private Dictionary<string, string> _ExtraInfo = new Dictionary<string, string>();
        
        public Dictionary<string, string> ExtraInfo {
            get { return _ExtraInfo; }
            set { _ExtraInfo = value; }
        }
    
    }
