    public class DayMeals
    {
	   private int[] entryTimes = new int[] { 6, 12, 17 };
	   private int[] exitTimes = new int[] { 8, 14, 19 };
	   private int[] mealCounts = new int[3];
	   private bool countHalfMeals = false;
	   public DayMeals(bool countHalfMeals)
	   {
		   this.countHalfMeals = countHalfMeals;
	   }
	   public void AddFullDay()
	   {
		   mealCounts[0]++;
		   mealCounts[1]++;
		   mealCounts[2]++;
	   }
	   public void CountMealsForADay(DateTime timeArrived, DateTime timeExit)
	   {
		   for (int i = 0; i < mealCounts.Length; i++)
		   {
			   int mealEntryTime = entryTimes[i];
			   int mealExitTime = exitTimes[i];
			   if (timeArrived.Hour <= mealEntryTime && timeExit.Hour >= mealExitTime)
				   mealCounts[i]++;
			   else if (countHalfMeals && timeExit.Hour > mealEntryTime && timeExit.Hour <= mealExitTime)
				   mealCounts[i]++;
		   }
	   }
	   public void PrintMealsCount()
	   {
		   for (int i = 0; i < mealCounts.Length; i++)
		   {
			   System.Console.WriteLine($"Meal #{i + 1} count = {mealCounts[i]}");
		   }
	   }
    }
