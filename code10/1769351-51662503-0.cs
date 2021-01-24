	public interface INotify<out T> where T: EventArgs {}
	
	public class MyEventArgs : EventArgs {}
	
	class MyClass : INotify<MyEventArgs> {}
						
	public class Program
	{
		
		private static void doSomethingWithINotifyObject<T>(INotify<T> notify) where T : EventArgs
		{
			Console.WriteLine("Hello world");
		}
		
		public static void Main()
		{
			var instance = new MyClass();
			var o = instance as INotify<EventArgs>;
			if (o != null)
			{
				doSomethingWithINotifyObject(o);
			}
		}
	}
