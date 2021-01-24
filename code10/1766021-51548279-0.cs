    class MyClass
    {
        protected readonly List<EventHandler> list = new List<EventHandler>();
			
        public event EventHandler DoWork
        {
            add
            {
				list.Add(value);
            }
            remove
            {
				list.Remove(value);
            }
        }
		
		public void RaiseDoWork()
		{
			var args = new EventArgs();
			foreach (var func in list)
			{
				func(this, args);
			}
		}
		
		public IEnumerable<EventHandler> GetDoWorkDelegates()
		{
			return list;
		}
    }
		
		
	public class Program
	{
		public static void HandleDoWork(object sender, EventArgs e)
		{
			Console.WriteLine("Event fired.");
		}
		
		public static void Main()
		{
			var c = new MyClass();
			c.DoWork += HandleDoWork; 
			c.RaiseDoWork();
			
			foreach (var d in c.GetDoWorkDelegates())
			{
				Console.WriteLine("Method name was {0}.", d.Method.Name);
			}
		}
	}
