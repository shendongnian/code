    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]        
        [NetDataContract]
        List<Staff> GetStaff();
        
        [OperationContract]        
        void RegisterClinician(Clinician clinician);
        
        [OperationContract]        
        void Register(Secretary secretary);
    }
    
    [DataContract]
    public class Staff
    {
        public string Name { get; set; }
    }
    
    [DataContract]
    public class Clinician:Staff
    {
    }
    
    [DataContract]
    public class Secretary:Staff
    {
    }
