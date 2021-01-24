    public class EmployeeComparer : IEqualityComparer<Employee>
    {
    	public int GetHashCode(Employee co)
    	{
    		if (co == null)
    		{
    			return 0;
    		}
    		return co.EmployeeId.GetHashCode();
    	}
    
    	public bool Equals(Employee x1, Employee x2)
    	{
    		if (object.ReferenceEquals(x1, x2))
    		{
    			return true;
    		}
    		if (object.ReferenceEquals(x1, null) ||
    			object.ReferenceEquals(x2, null))
    		{
    			return false;
    		}
    		// Here just check each property to make sure they all match before returning
    		return x1.EmployeeId == x2.EmployeeId && x1.Employmentstatus == x2.Employmentstatus && x1.Firstname == x2.Firstname && x1.Lastname == x2.Lastname;
    
    	}
    
    }
