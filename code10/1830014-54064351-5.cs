    void Main(string[] args)
    {
	   CalculateMeals(new DateTime(2019, 1, 1, 15, 12, 1), new DateTime(2019, 1, 2, 18, 0, 0));
    }
    public static void CalculateMeals(DateTime timeArrived, DateTime timeExit)
    {
	   // Number of full days
	   int hoursDiff = (int)(timeExit - timeArrived).TotalHours;
	   int fullDaysNumber = (timeExit - timeArrived).Days;
	   DayMeals dayMeals = new DayMeals(true);
	   for (int i = 0; i <= fullDaysNumber; i++)
	   {
		   if (timeExit.Day > timeArrived.Day && hoursDiff > 24)
		   {
			   dayMeals.AddFullDay();
			   // A trick to make the cycle work the next time
			   // You can use a different variable if you want to keep timeArrived unchanged
			   timeArrived = timeArrived.AddDays(1);
		   }
		   else if (timeExit.Day < timeArrived.Day)
		   {
			   break;
		   }
		   else
		   {
			   if (fullDaysNumber == 0 && timeArrived.Day != timeExit.Day)
			   {
				   dayMeals.CountMealsForADay(timeArrived, new DateTime(1,1,timeArrived.Day,23,59,59));
				   dayMeals.CountMealsForADay(new DateTime(1,1,timeExit.Day,0,0,1), timeExit);
			   }
			   else
			   {
				   dayMeals.CountMealsForADay(timeArrived, timeExit);
			   }	
		   }
	   }
	   dayMeals.PrintMealsCount();
    }
        
