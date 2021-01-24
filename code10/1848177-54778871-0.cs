    public class Program
    {
        static public void Main()
        {
            var library = new Library();
            library.Callback = GetMoreData;
            var task = Task.Run( () => library.Foo() );
			Console.WriteLine("Other thread is running.");
			task.Wait();
        }
        static string GetMoreData()
        {
            return "More data";
        }
    }
    class Library
    {
        public Func<string> Callback { get; set; }
        public async Task Foo()
        {
			for (int i=0; i<10; i++)
			{
                var moreData = Callback();
                Console.WriteLine("Library received this data: {0}", moreData);
				await Task.Delay(500);
			}
        }
    }    
    
