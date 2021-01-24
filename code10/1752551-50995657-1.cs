    private class UserServiceDataEqualityComparer : IEqualityComparer<UserServiceData>
    {
    	public bool Equals(UserServiceData x, UserServiceData y)
    	{
    		return x.name == y.name;
    	}
    
    	public int GetHashCode(UserServiceData obj)
    	{
    		return obj.name.GetHashCode();
    	}
    }
