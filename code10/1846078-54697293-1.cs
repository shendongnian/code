    public class EmployeeComparer : IEqualityComparer<Employee>
    {
    	public int GetHashCode(Employee co)
    	{
    		if (co == null)
    		{
    			return 0;
    		}
    
    		//You can use any property you want (other than EmployeeID for your purposes); the GetHashCode metho is used to generate an address to where the object is stored
    		return co.Employmentstatus.GetHashCode();
    	}
    
    	public bool Equals(Employee x1, Employee x2)
    	{
    		if (object.ReferenceEquals(x1, x2))
    		{
    			return true;
    		}
    
    		if (object.ReferenceEquals(x1, null) || object.ReferenceEquals(x2, null))
    		{
    			return false;
    		}
    		
            // Check for equality with all properties except for EmployeeID
    		return x1.Employmentstatus == x2.Employmentstatus && x1.Firstname == x2.Firstname && x1.Lastname == x2.Lastname;
    	}
    }
