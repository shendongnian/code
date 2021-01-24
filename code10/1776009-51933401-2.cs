    class ClientComparer : IEqualityComparer<NeWClient>
    {
    	public bool Equals(NeWClient x, NeWClient y)
    	{
    		return x.ClientID == y.ClientID &&
    		x.ClientName == y.ClientName &&
    		x.companyLocation == y.companyLocation &&
    		x.companyName == y.companyName;
    	}
    
    	public int GetHashCode(NeWClient obj)
    	{
    		unchecked
    		{
    			if (obj == null)
    				return 0;
    			int hashCode = obj.ClientID.GetHashCode();
    			hashCode = hashCode * 23 + obj.ClientName.GetHashCode();
    			hashCode = hashCode * 23 + obj.companyLocation.GetHashCode();
    			hashCode = hashCode * 23 + obj.companyName.GetHashCode();
    			return hashCode;
    		}
    	}
    }
    
    class NewClientIDComparer : IEqualityComparer<NeWClient>
    {
    	public bool Equals(NeWClient x, NeWClient y)
    	{
    		return x.ClientID == y.ClientID;
    	}
    
    	public int GetHashCode(NeWClient obj)
    	{
    		unchecked
    		{
    			if (obj == null)
    				return 0;
    			int hashCode = obj.ClientID.GetHashCode();
    			return hashCode;
    		}
    	}
    }
