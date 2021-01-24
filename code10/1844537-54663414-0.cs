        [ServiceContract(Namespace ="http://mydomain")]
        public interface IGetMessage
        {
            [OperationContract]
            string ShowMessage(Sample p, string Username, string Password);
        }
    
        [DataContract(Namespace = "http://mydomain")]
        public class Sample
        {
            [DataMember]
            public string Name { get; set; }
    }
