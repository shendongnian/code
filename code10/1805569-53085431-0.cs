    public static int IncreaseCounter_DailySiteVisitors()
    {
	    private readonly object somethingObject = new object();
	    var context = new MyProjectEntities() 
	    var today = DateTime.Now;
	    var todaysRecord = context.CounterDailyVisitor
                    .SingleOrDefault(x => x.DateRecord.Year == Today.Year
						        && x.DateRecord.Month == Today.Month
							   && x.DateRecord.Day == Today.Day
					);
	    if (todaysRecord != null)
	    {
		   //the existing count + 1
		   todaysRecord.Count = todaysRecord.Count++;
	    }
	    else
	    {
	
		   Lock(somethingObject)
		   {
			   //recheck
			   var todaysRecord = context.CounterDailyVisitor
                       .SingleOrDefault(x => x.DateRecord.Year == Today.Year
						   && x.DateRecord.Month == Today.Month
						&& x.DateRecord.Day == Today.Day
					);
			   if (todaysRecord != null)
			   {
				   //the existing count + 1
				   todaysRecord.Count = todaysRecord.Count++;
			   }
			   else
			   {
				var newRecordObj = new CounterDailyVisitor();
				newRecordObj.Count = 1;
				newRecordObj.DateRecord =  DateTime.Now; //this shouldnt be nullable
				
				context.CounterDailySiteVisitor.Add(newRecordObj);
			   }	
		    }
	    }
	    context.SaveChanges();
    }
