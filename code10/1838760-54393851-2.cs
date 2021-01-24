    public void RunProgram()
    {
       int i;
       Random rollingDie = new Random ();
       Console.WriteLine("Numbers 1 to 6");
       var list = new List<int>();
       for (i =0; i < 200; i++)
       {
        var newItem = rollingDie.Next(1,7);
    	list.Add(newItem);
        Console.WriteLine("Next is: {0}", newItem);
    	var occurance = FindOccurance(list,newItem);
    	Console.WriteLine($"{newItem} has occured {occurance} times");
       }
        
    }
    
    public int FindOccurance(List<int> list,int currentItem)
    {
    	return list.Count(x=>x == currentItem);
    }
