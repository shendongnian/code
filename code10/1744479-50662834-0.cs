    static async Task Main(string[] args) //async Main supported in C#7
    {
    	var now = DateTime.UtcNow; //always use UTC, calculating timezones costs time
    	var startOfCurrentTimePeriod = 
            new DateTime(now.Year, 
                         now.Month, 
                         now.Day, 
                         now.Hour, 
                         now.Minute, 
                         now.Second, 
                         0,         //set this ms part to 0
                         DateTimeKind.Utc);
    	var triggerTime = oClock.AddSeconds(1); //when we want to run our action
    	while (true)
    	{
    		var waitTime = triggerTime - DateTime.UtcNow;
    		if (waitTime > TimeSpan.Zero) //if we have a negative wait time, just go
    		{
    			await Task.Delay(waitTime);
    		}
    		triggerTime = triggerTime.AddSeconds(1); //set the next time
    		//perform action
    		Console.WriteLine($"the time is : {triggerTime}");
        }
    }
