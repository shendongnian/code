    public interface IMyServiceProxy : IGeneratedServiceProxy
    {
       void GetEntityAsync(GetEntityRequest request);
       void GetEntityAsync(GetEntityRequest request, object userState);
       event EventHandler<GetEntityCompletedEventArgs> GetEntityCompleted;
    }
