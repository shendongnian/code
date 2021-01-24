    <!-- language: c# -->
    	public SqlString Terminate()
    	{
    		string _Aggregation = null;
    
    		if (aggregationList != null && aggregationList.Count > 0)
    		{
    			aggregationList.Sort();
    			_Aggregation = string.Join(CommaSpaceSeparator, aggregationList);
    		}
    
    		return new SqlString(_Aggregation);
    	}
    
    	public void Read(BinaryReader r)
    	{
    		int _Count = r.ReadInt32();
    		aggregationList = new List<string>(_Count);
    
    		for (int _Index = 0; _Index < _Count; _Index++)
    		{
    			aggregationList.Add(r.ReadString());
    		}
    	}
    
    	public void Write(BinaryWriter w)
    	{
    		w.Write(aggregationList.Count);
    		foreach (string _Item in aggregationList)
    		{
    			w.Write(_Item);
    		}
    	}
