        class Program
    	{
    		static void Main(string[] args)
    		{
    			// Test
    			DateTime deadline = DeadlineManager.CalculateDeadline(DateTime.Now, new TimeSpan(4, 0, 0));
    			Console.WriteLine(deadline);
    			Console.ReadLine();
    		}
    	}
    
    	static class DeadlineManager
    	{
    		public static DateTime CalculateDeadline(DateTime start, TimeSpan workhours)
    		{
    			DateTime current = new DateTime(start.Year, start.Month, start.Day, start.Hour, start.Minute, 0);
    			while(workhours.TotalMinutes > 0)
    			{
    				DayOfWeek dayOfWeek = current.DayOfWeek;
    				Workday workday = Workday.GetWorkday(dayOfWeek);
    				if(workday == null)
    				{
    					DayOfWeek original = dayOfWeek;
    					while (workday == null)
    					{
    						current = current.AddDays(1);
    						dayOfWeek = current.DayOfWeek;
    						workday = Workday.GetWorkday(dayOfWeek);
    						if (dayOfWeek == original)
    						{
    							throw new InvalidOperationException("no work days");
    						}
    					}
    					current = current.AddHours(workday.startTime.Hour - current.Hour);
    					current = current.AddMinutes(workday.startTime.Minute - current.Minute);
    				}
    
    				TimeSpan worked = Workday.WorkHours(workday, current);
    				if (workhours > worked)
    				{
    					workhours = workhours - worked;
    					// Add one day and reset hour/minutes
    					current = current.Add(new TimeSpan(1, current.Hour * -1, current.Minute * -1, 0));
    				}
    				else
    				{
    					current.Add(workhours);
    					return current;
    				}
    			}
    			return DateTime.MinValue;
    		}
    	}
    
    	class Workday
    	{
    		private static readonly Dictionary<DayOfWeek, Workday> Workdays = new Dictionary<DayOfWeek, Workday>(7);
    		static Workday()
    		{
    			Workdays.Add(DayOfWeek.Monday, new Workday(DayOfWeek.Monday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 16, 0, 0)));
    			Workdays.Add(DayOfWeek.Tuesday, new Workday(DayOfWeek.Tuesday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 16, 0, 0)));
    			Workdays.Add(DayOfWeek.Wednesday, new Workday(DayOfWeek.Wednesday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 16, 0, 0)));
    			Workdays.Add(DayOfWeek.Thursday, new Workday(DayOfWeek.Thursday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 16, 0, 0)));
    			Workdays.Add(DayOfWeek.Friday, new Workday(DayOfWeek.Friday, new DateTime(1, 1, 1, 10, 0, 0), new DateTime(1, 1, 1, 14, 0, 0)));
    		}
    
    		public static Workday GetWorkday(DayOfWeek dayofWeek)
    		{
    			if (Workdays.ContainsKey(dayofWeek))
    			{
    				return Workdays[dayofWeek];
    			}
    			else return null;
    		}
    
    		public static TimeSpan WorkHours(Workday workday, DateTime time)
    		{
    			DateTime sTime = new DateTime(time.Year, time.Month, time.Day,
    				workday.startTime.Hour, workday.startTime.Millisecond, workday.startTime.Second);
    			DateTime eTime = new DateTime(time.Year, time.Month, time.Day,
    				workday.endTime.Hour, workday.endTime.Millisecond, workday.endTime.Second);
    			if (sTime < time)
    			{
    				sTime = time;
    			}
    			TimeSpan span = eTime - sTime;
    			return span;
    		}
    
    		public static DayOfWeek GetNextWeekday(DayOfWeek dayOfWeek)
    		{
    			int i = (dayOfWeek == DayOfWeek.Saturday) ? 0 : ((int)dayOfWeek) + 1;
    			return (DayOfWeek)i;
    		}
    
    
    		private Workday(DayOfWeek dayOfWeek, DateTime start, DateTime end)
    		{
    			this.dayOfWeek = dayOfWeek;
    			this.startTime = start;
    			this.endTime = end;
    		}
    
    		public DayOfWeek dayOfWeek;
    		public DateTime startTime;
    		public DateTime endTime;
    	}
