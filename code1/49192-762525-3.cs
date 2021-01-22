	[Serializable]
	public class Data
	{
		int a;
		int b;
	}
	[Serializable]
	public class ResultData
	{
		int c;
	}
	public interface IServerInterface
	{
		ResultData DoSomething(Data data);
	}
