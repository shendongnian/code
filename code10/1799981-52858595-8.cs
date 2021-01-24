    DateTime DeliveryStart = new DateTime(2018, 10, 17);
            
	//List of Recipients (fake populate function)
	IEnumerable<int> allRecipients = PopulateRecipients();            
	
	// Scheduling restrictions 
	int maxPerMinute = 90;
	int maxPerHour = 270;
	//Creates groups broken down by the max per minute.  
	var groupsPerMinute = allRecipients
			.Select((s, i) => new { Value = s, Index = i })
			.GroupBy(x => x.Index / maxPerMinute)
			.Select(group => group.Select(x => x.Value).ToArray());
    //This will be the resulting groups
	var deliveryDateGroups = new List<RecipientGroup>();
    //Perform an aggregate run on the groups using the iterator
	groupsPerMinute.Aggregate(new GroupIterator(DeliveryStart), (iterator, ids) => 
	{
        var nextBreak = iterator.Count + ids.Count();
		if (nextBreak >= maxPerHour)
		{
			//Will go over limit, split
			var difference = nextBreak-maxPerHour;
			var groupSize = ids.Count() - difference;
			//This group completes the batch
			var group = new RecipientGroup(iterator.ScheduledDateTime, ids.Take(groupSize));
			deliveryDateGroups.Add(group);
			var newDate = iterator.ScheduledDateTime.AddHours(1).AddMinutes(-iterator.ScheduledDateTime.Minute);
			//Add new group with remaining recipients.
			var stragglers = new RecipientGroup(newDate, ids.Skip(groupSize));
			deliveryDateGroups.Add(stragglers);
  		    return new GroupIterator(newDate, difference);
		}                    
		else
		{
			var group = new RecipientGroup(iterator.ScheduledDateTime, ids);
			deliveryDateGroups.Add(group);
			iterator.ScheduledDateTime = iterator.ScheduledDateTime.AddMinutes(1);
			iterator.Count += ids.Count();
			return iterator;
		}                      
	});
    //Output minute group count
	Console.WriteLine($"Group count: {deliveryDateGroups.Count}");
    //Groups by hour
    var byHour = deliveryDateGroups.GroupBy(g => new DateTime(g.ScheduledDateTime.Year, g.ScheduledDateTime.Month, g.ScheduledDateTime.Day, g.ScheduledDateTime.Hour, 0, 0));
    Console.WriteLine($"Hour Group count: {byHour.Count()}");
    foreach (var group in byHour)
    {
         Console.WriteLine($"Date: {group.Key.ToShortDateString()} {group.Key.ToShortTimeString()}; Count: {group.Count()}; Recipients: {group.Sum(g => g.Recipients.Count())}");
    }
