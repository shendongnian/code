    class RowComparer : IEqualityComparer<DataRow>
    {
    	public bool Equals(DataRow x, DataRow y)
    	{
    		return x["Col1"] == y["Col1"];
    	}
    
    	public int GetHashCode(DataRow obj)
    	{
    		return obj["Col1"].GetHashCode();
    	}
    }
