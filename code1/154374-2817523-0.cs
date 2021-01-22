    [ServiceContract]
    public interface IContract1
    {
        [OperationContract(Name="AddInt")]
        double Add(int ip);
    }
    
    [ServiceContract]
    public interface IContract2
    {
        [OperationContract(Name="AddDouble")]
        double Add(double ip);
    }
