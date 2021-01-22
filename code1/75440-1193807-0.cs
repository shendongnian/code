    List< MyClass> listRes = new List< MyClass>();
    foreach ( MyClass item in list1)
    {
    	var exist = list2
    		.Select(x => x.MyClass)
    		.Contains(item);
    
    	if (!exist)
    		listRes.Add(item);
    	else
    	{
    		var totalFromOther = list2
    			.Where(x => x.MyClass.Id == item.Id)
    			.Sum(y => y.HourBy);
    			
    		if (item.HourBy != totalFromOther)
    		{        
    			item.HourBy = item.HourBy - totalFromOther;
    			listRes.Add(item);
    		}            
    	}   
    }
