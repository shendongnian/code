    private static test(){
    	List<Task<float>> tasks = new List<Task<float>>();
    	for (float i = -3.0f; i <= 3.0f; i+=1.0f)
    	{
    		float num = i;
    		Console.WriteLine("sent " + i);
    		Task<float> task = Task.Factory.StartNew<float>(() => Div(5.0f, num));
    		tasks.Add(task);
    	}
    
    	foreach(Task<float> t in tasks)
    	{
    		try
    		{
    			t.Wait();
    			if (t.IsFaulted)
    			{
    				Console.WriteLine("Something went wrong: " + t.Exception.Message);
    			}
    			else
    			{
    				Console.WriteLine("result: " + t.Result);
    			}
    		}catch(Exception ex)
    		{
    			Console.WriteLine("Error: " + ex.Message);
    		}
    		
    	}
    }
    
    private static float Div(float a, float b)
    {
    	Console.WriteLine("got " + b);
    	if (b == 0) throw new Exception("Divide by zero");
    	return a / b;
    }
