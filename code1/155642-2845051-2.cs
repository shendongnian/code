    public static partial class MoreEnumerable
    {
        public static IEnumerable<TResult> GenerateByIndex<TResult>(Func<int, TResult> generator)
        {
            // Looping over 0...int.MaxValue inclusive is a pain. Simplest is to go exclusive,
            // then go again for int.MaxValue.
            for (int i = 0; i < int.MaxValue; i++)
            {
                yield return generator(i);
            }
            yield return generator(int.MaxValue);
        }
    }
	public class MyClass
    {
    	private void test()
		{
			DateTime startDate = DateTime.Now.AddDays(-29);
			DateTime endDate = DateTime.Now.AddDays(1);
			using (var dc = new DataContext())
			{
				//get database sales from 29 days ago at midnight to the end of today
				var salesForPeriod = dc.Orders.Where(b => b.OrderDateTime > startDate.Date  && b.OrderDateTime <= endDate.Date);
        
				var allDays = MoreEnumerable.GenerateByIndex(i => startDate.AddDays(i)).Take(30);
				var salesByDay = from s in salesForPeriod
							group s by s.OrderDateTime.Date into g
							select new {Day = g.Key, totalSales = g.Sum(x=>(decimal)x.OrderPrice};
				
				var query = from d in allDays
							join s in salesByDay on s.Day equals d into j
							select (s != null) ? s.totalSales : 0m;
 
			}
		}
    }
