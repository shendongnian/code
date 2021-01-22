    public static IList<Item> _list;
    
    public void DoSomething()
    {
        while (true)
        {
        	DateTime minDate = DateTime.MaxValue;
        
            for (int i = 0; i < _list.Count; i++)
            {
                DateTime nextExecution = _list[i].LastUpdate.AddMinutes(_list[i].Time);
                
                if (nextExecution <= DateTime.Now)
                {
    	            var item = DoWork(_list[i].Url);
    	            _list[i].LastUpdate = item.LastUpdate;
    	            nextExecution = _list[i].LastUpdate.AddMinutes(_list[i].Time);
    	            Console.WriteLine(item.Title + " @ " + item.LastUpdate + "; i = " + i);
                }
                
                if (nextExecution < minDate)
                	minDate = nextExecution;
            }
            
            TimeSpan timeToSleep = minDate.Subtract(DateTime.Now));
                
    	    if (timeToSleep.TotalMilliseconds > 0)
    	    {
    	        Console.WriteLine("Sleeping until: " + minDate);
    	        System.Threading.Thread.Sleep(timeToSleep);
    	    }
        }
    }
