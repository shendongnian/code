	[ServiceContract]
	public interface IMyServiceClient : IMyService, IDisposable
	{
		[OperationContract(Action = "http://IMyService/DoWork", ReplyAction = "http://IMyService/DoWorkResponse")]
		Task<bool> DoWorkAsync(int i);
	}
	
	[ServiceContract]
	public interface IMyService
    {
		[OperationContract(Action = "http://IMyService/DoWork", ReplyAction = "http://IMyService/DoWorkResponse")]
		bool DoWork(int i);
    }
