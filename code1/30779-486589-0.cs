    [Serializable]
    public class Error
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public Error()
        {
            this.TimeStamp = DateTime.Now;
        }
        public Error(string Message) : this()
        {
            this.Message = Message;
        }
        public Error(System.Exception ex) : this(ex.Message)
        {
            this.StackTrace = ex.StackTrace;
        }
        public override string ToString()
        {
            return this.Message + this.StackTrace;
        }
    }
