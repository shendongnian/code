    [ServiceContract]
    public interface IContract1
    {
        [OperationContract(Name = "Add1")]
        double Add(int ip);
    }
    
    [ServiceContract]
    public interface IContract2
    {
        [OperationContract(Name = "Add2")]
        double Add(double ip);
    }
