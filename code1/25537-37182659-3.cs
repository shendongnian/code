	[ServiceContract]
	public interface IMyService
    {
		[OperationContract]
		bool DoWork(int i);
    }
