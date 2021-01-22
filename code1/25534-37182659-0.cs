	[ServiceContract]
	public interface IIndicesReaderClient : IIndicesReader
	{
		[OperationContract(Action = "http://IIndicesReader/DoWork", ReplyAction = "http://IIndicesReader/DoWorkResponse")]
		Task<bool> DoWorkAsync(SourceType indexSource, string uniqueName);
	}
	
	[ServiceContract]
	public interface IIndicesReader
    {
		[OperationContract(Action = "http://IIndicesReader/DoWork", ReplyAction = "http://IIndicesReader/DoWorkResponse")]
		bool DoWork(SourceType indexSource, string uniqueName);
    }
