	public class ServerObject : MarshalByRefObject, IServerInterface
	{
		public ResultData DoSomething(Data data)
		{
			// do some work
			return new ResultData();
		}
	}
