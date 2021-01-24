	public class Test
	{
		public string Prop1 {get; set;}
		public string Prop2 {get; set;}
		public string Prop3 {get; set;}
		public string Prop4 {get; set;}
	}
	public class Program
	{
		public static void Main()
		{
				var test = new Test(){
					Prop1 = "Test1",
					Prop2 = "Test2",
					Prop3 = "Test3",
					Prop4 = "Test4"
				};
			
				foreach (var property in test.GetType().GetProperties())
				{
					Console.WriteLine("{0} = {1}", property.Name, property.GetValue(test));
				}
		}
	}
