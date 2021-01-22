    [DataContract]
    public class ErrorBase
    {
        public virtual string Message { get { return _Message; } }
        [DataMember(Name="Message")]
        private string _Message { get; set; }
    }
