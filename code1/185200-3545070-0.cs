    [ServiceContract(Namespace = "http://www.example.com")]
    public interface IAilDataService
    {
        [OperationContract]
        [FaultContract(typeof(OperationPermissionFault))]
        [FaultContract(typeof(InvalidOperationException))]
        void Method1();
    }
