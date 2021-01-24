     public static Dictionary<String, int> processData(IEnumerable<string> lines)
        {
    		
    		Dictionary<String, int> retValue = new Dictionary<String, int>();
    		foreach(var line in lines)
    		{
    			var values = line.Split(new []{","},StringSplitOptions.RemoveEmptyEntries);
    			var currentDepartment = values[2];
    			var currentSalary = int.Parse(values[3]);
    			
    			if(!retValue.ContainsKey(currentDepartment))
    				retValue.Add(values[2],int.Parse(values[3]));
    			else if(retValue[currentDepartment]<currentSalary)
    					retValue[currentDepartment] = currentSalary;
    				
    		}
            
            return retValue;
        }
