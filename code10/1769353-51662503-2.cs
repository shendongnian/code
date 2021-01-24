    public interface INotificationArgs
	{
	}
	
	public interface INotify<out T> where T: EventArgs, INotificationArgs
	{
		void PrintName();
	}
	
	public class MyEventArgsBase : EventArgs, INotificationArgs {}
	public class MyEventArgs1 : MyEventArgsBase {}
	
	public class MyEventArgs2 : MyEventArgsBase {}
  
    public class MyEventArgs3 : MyEventArgsBase {}
	
	class MyClass<T> : INotify<T> where T : EventArgs, INotificationArgs
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
		
		private static void doSomethingWithINotifyObject<T>(INotify<T> notify) where T : EventArgs, INotificationArgs
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
				var i = o as INotify<MyEventArgsBase>;
				if (i != null)
				{
					doSomethingWithINotifyObject(i);
				}
			}
		}
	}
