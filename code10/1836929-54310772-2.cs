    public class Comparer : IEqualityComparer<Ranking>
    {
    	public bool Equals(Ranking l, Ranking r)
    	{
    		return l.JOB_ID == r.JOB_ID || l.EMPLOYEE_ID == r.EMPLOYEE_ID;
    	}
    
    	public int GetHashCode(Ranking obj)
    	{
    		return 1;
    	}
    }
