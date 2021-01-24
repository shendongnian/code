    public static Dictionary<String, int> processData(IEnumerable<string> lines)
    {
    			Dictionary<String, int> retVal = new Dictionary<String, int>();
    			foreach(var line in lines)
    			{
    				var values = line.Split(new []{","},StringSplitOptions.RemoveEmptyEntries);
    				retVal.Add(values[1],int.Parse(values[3]));
               }
                
               return retVal;
    }
