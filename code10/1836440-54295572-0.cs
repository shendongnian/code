    public class CustomComparer : IComparer<string>
    {
       public int Compare(string stringA, string stringB)
        {
    		var isValueAInt = int.TryParse(stringA, out var valueA);
    		var isValueBInt = int.TryParse(stringB, out var valueB);
    		
    		if(isValueAInt && isValueBInt)
    		{
    			return valueA - valueB;
    		}
    		else if(isValueAInt && !isValueBInt)
    		{
    			return-1;
    		}
    		else if(!isValueAInt && isValueBInt)
    		{
    			return 1;
    		}
            return String.Compare(stringA,stringB);
    
        }
    }
