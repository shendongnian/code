	class Class1
	{
		public Class1(IService service)
		{
			service.Add("123");
		}
	}
	
	class Class2
	{
		public Class2(IService service)
		{
			var data = service.Get(); // return NOT null
			Console.WriteLine(data);
		}
	}
	
	public interface IService 
	{ 
		string Get();
		void Add(string item);
	}
	
	public class Service : IService 
	{ 
		private string value;
		public string Get()=>value;
		public void Add(string item)=>value = item;
	}
