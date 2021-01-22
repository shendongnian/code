	public class SomeonesDllService : ISomeonesDllService
	{
		public IList<string> GetList(string param1)
		{
			return StaticClass.GetList(param1);
		}
	}
