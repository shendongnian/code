    [ServiceContract(Namespace = "")]    
    public interface ITaskService
    {
        [OperationContract]
        List<int> GetTasks(int id, int type);
    }
