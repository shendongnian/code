    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public interface ITaskService
    {
        [OperationContract]
        List<int> GetTasks(int id, int type);
    }
