	public class Comparer : IEqualityComparer<Rankings>
	{
		public bool Equals(Rankings l, Rankings r)
    	{
        	return (l.JOB_ID + l.EMPLOYEE_ID) == (r.JOB_ID + r.EMPLOYEE_ID);
    	}
		public int GetHashCode(Rankings obj)
		{
			return obj.JOB_ID ^ obj.EMPLOYEE_ID;
		}
	}
    rankings
        .GroupBy(_ => _, new Comparer())
        .Where(g => g.Key.JOB_ID != g.Key.EMPLOYEE_ID)
        .Select(g => g.First()) //take the first element of each group
