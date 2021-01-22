    [DataContract]
    public class MyFaultException
    {
        [DataMember(Name="Reason")]
        private string _reason;
        public string Reason { get { return _reason; } }
    }
