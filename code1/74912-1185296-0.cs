    [ServiceContract]
    public interface IApplicationRegistration
    {
        // Sends the application information
        [OperationContract]
        bool RegisterApplication(AppInfo appInfo);
    }
