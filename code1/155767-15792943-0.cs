	void Main()
	{
		object locker = new object();
		IEnumerable<string> myList0 = new DataGetter().GetData(locker, "List 0");
		IEnumerable<string> myList1 = new DataGetter().GetData(locker, "List 1");
		IEnumerable<string> myList2 = new DataGetter().GetData(locker, "List 2");
	
		Console.WriteLine("start Getdata");
		// Demonstrate that breaking out of a foreach loop releasees the lock
		var t0 = new Thread(() => {
			foreach( var s0 in myList0 )
			{
				Console.WriteLine("List 0 {0}", s0);
				if( s0 == "2" ) break;
			}
		});
		Console.WriteLine("start t0");
		t0.Start();
		t0.Join(); // Acts as 'wait for the thread to complete'
		Console.WriteLine("end t0");
		
		// t1's foreach loop will start (meaning previous t0's lock was cleared
		var t1 = new Thread(() => {
			foreach( var s1 in myList1)
			{
				Console.WriteLine("List 1 {0}", s1);
				// Once another thread will wait on the lock while t1's foreach
				// loop is still active a dead-lock will occure.
				var t2 = new Thread(() => {
					foreach( var s2 in myList2 )
					{
						Console.WriteLine("List 2 {0}", s2);
					}
				} );
				Console.WriteLine("start t2");			
				t2.Start();
				t2.Join();
				Console.WriteLine("end t2");			
			}
		});
		Console.WriteLine("start t1");
		t1.Start();
		t1.Join();
		Console.WriteLine("end t1");
		Console.WriteLine("end GetData");
	}
	
	void foreachAction<T>( IEnumerable<T> target, Action<T> action )
	{
		foreach( var t in target )
		{
			action(t);
		}
	}
	
	public class DataGetter
	{
		private List<string> _data = new List<string>() { "1", "2", "3", "4", "5" };
		
		public IEnumerable<string> GetData(object lockObj, string listName)
		{
			Console.WriteLine("{0} Starts", listName);
			lock (lockObj)
			{
				Console.WriteLine("{0} Lock Taken", listName);
				foreach (string s in _data)
				{
					yield return s;
				}
			}
			Console.WriteLine("{0} Lock Released", listName);
		}
	}
