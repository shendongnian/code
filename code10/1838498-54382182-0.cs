    var listOfNumbers = numbers.Split(new[]{" "},StringSplitOptions.RemoveEmptyEntries)
    	               .Select(x=> 
    				   	{
    						Console.WriteLine(x);
    						if(Int32.TryParse(x,out var number))
    							return number;
    						else
    							throw new Exception("Element is not a number");
    					});
