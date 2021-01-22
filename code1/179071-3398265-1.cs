    static void Main(string[] args)
    {
    	Example();
    }
    
    static BlockingCollection<Tuple<int, int, string>> _progressMessages = 
    	new BlockingCollection<Tuple<int, int, string>>();
    
    public static void Example()
    {
    	List<Task<int>> tasks = new List<Task<int>>();
    
    	for (int i = 0; i < 10; i++)
    		tasks.Add(Task.Factory.StartNew((object state) =>
    			{
    				int id = (int)state;
    				DoFirstStep(id);
    				_progressMessages.Add(new Tuple<int, int, string>(
    					id, 1, "10.0%"));
    				DoSecondStep(id);
    				_progressMessages.Add(new Tuple<int, int, string>(
    					id, 2, "50.0%"));
    
    				// ...
    
    				return 1;
    			},
    			(object)i
    			));
    
    	Task logger = Task.Factory.StartNew(() =>
    		{
    			foreach (var m in _progressMessages.GetConsumingEnumerable())
    				Console.WriteLine("Task {0}: Step {1}, progress {2}.",
					m.Item1, m.Item2, m.Item3);
    		});
    
    			
    	List<Task> waitOn = new List<Task>(tasks.ToArray());
    	waitOn.Add(logger);
    	Task.WaitAll(waitOn.ToArray());
    	Console.ReadLine();
    }
    
    private static void DoSecondStep(int id)
    {
    	Console.WriteLine("{0}: First step", id);
    }
    
    private static void DoFirstStep(int id)
    {
    	Console.WriteLine("{0}: Second step", id);
    }
