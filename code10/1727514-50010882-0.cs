    class DownloadFileAddressComparer : IEqualityComparer<DownloadFile>
    {
    	public bool Equals(DownloadFile x, DownloadFile y)
    	{
    		return string.Equals(x?.Address, y?.Address);		
    	}
    	public int GetHashCode(DownloadFile obj)
    	{
    		return obj.Address?.GetHashCode() ?? 0; // In case of null address
    	}
    }
    /* ... */    
	var newList = listOne.Concat(listTwo)
                  .Distinct(new DownloadFileAddressComparer())
                  .ToList();
