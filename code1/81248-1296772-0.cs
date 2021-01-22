    [ServiceContract]
    public interface IMyServiceContract
    {
        [FaultContract(typeof(IntegerZeroFault))]
        [FaultContract(typeof(SomeOtherFault))]
        [OperationContract]
        public string GetSomeString(int someInteger);
    }
    
    [DataContract]
    public class IntegerZeroFault
    {
        [DataMember]
        public string WhichInteger {get;set;}
    }
    
    [DataContract]
    public class SomeOtherFault
    {
        [DataMember]
        public string ErrorMessage {get;set;}
    }
    
    public class MyService : IMyServiceContract
    {
        public string GetSomeString(int someInteger)
        {
            if (someInteger == 0) 
                throw new FaultException<IntegerZeroFault>(
                    new IntegerZeroFault{WhichInteger="someInteger"});
            if (someInteger != 42)
                throw new FaultException<SomeOtherFault>(
                    new SomeOtherFault{ErrorMessage ="That's not the anaswer"});
            return "Don't panic";
        }
    }
