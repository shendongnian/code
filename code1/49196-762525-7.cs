	public class ServerObject : MarshalByRefObject, IServerInterface
	{
		public ResultData DoSomething(Data data)
		{
			// do some work on the server
			return new ResultData();
		}
	}
