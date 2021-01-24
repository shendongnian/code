	public interface INotify<out T> where T: EventArgs
	{
		void PrintName();
	}
	
	public class MyEventArgs1 : EventArgs {}
	public class MyEventArgs2 : EventArgs {}
    public class MyEventArgs3 : EventArgs {}
	
	class MyClass<T> : INotify<T> where T : EventArgs
	{
		public string Name { get; set; }
		
		public MyClass(string name) { Name = name; }
		
		public void PrintName()
		{
			Console.WriteLine(Name);
		}
	}
						
	public class Program
	{
		
		private static void doSomethingWithINotifyObject<T>(INotify<T> notify) where T : EventArgs
		{
			notify.PrintName();
		}
		
		public static void Main()
		{
			object[] tests = new object []
			{
			    new MyClass<MyEventArgs1>("1"),
			    new MyClass<MyEventArgs2>("2"),
			    new MyClass<MyEventArgs3>("3")
			};
			
			foreach (var o in tests)
			{
				var i = o as INotify<EventArgs>;
				if (i != null)
				{
					doSomethingWithINotifyObject(i);
				}
			}
		}
	}
