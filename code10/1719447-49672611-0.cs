    		TimeSpan cutoverTime = TimeSpan.FromHours(6); // or however you have this defined
		// DateTime.Now is unstable, and the date may change between two consecutive calls
		// so read it into a temporary variable
		
		DateTime currentTime = DateTime.Now;
		DateTime startTime = currentTime.Date.Add(cutoverTime); // guess today
		if (startTime > currentTime)
		{
			// ok, guessed wrong, it was yesterday
			startTime = startTime.AddDays(-1);			
		}		
		DateTime endTime = startTime.AddDays(1);
		// And use parametised queries, not string concatenation (please)
		// SELECT SUM(sumtotal) from customertrans where DateTime >= @startTime and DateTime < @endTime
