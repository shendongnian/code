    class Program
    {
    	static void Main(string[] args)
    	{
    		List<Int32> testList = new List<Int32>();
    
    		foreach (Int32 i in testList)
    		{
    		}
    
    		using (var enumerator = testList.GetEnumerator())
    		{
    			while (enumerator.MoveNext())
    			{
    			}
    		}
    
    		using (IEnumerator<Int32> enumerator = testList.GetEnumerator())
    		{
    			while (enumerator.MoveNext())
    			{
    			}
    		}
    	}
    }
