     [DataContract]
    public class CalculatorFault
    {
        [DataMember]
        public string OperationName { get; set; }
       [DataMember]
        public string Fault { get; set; }
      
    }
 
