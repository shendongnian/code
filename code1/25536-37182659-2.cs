	[ServiceContract(Name= "IMyService")]
	public interface IMyServiceClient : IMyService
	{
		[OperationContract]
		Task<bool> DoWorkAsync(int i);
	}
	
	[ServiceContract]
	public interface IMyService
    {
		[OperationContract]
		bool DoWork(int i);
    }
