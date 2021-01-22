    class Program
    {
    	const int ReadBufferSize = 4096;
    
    	static void Main(string[] args)
    	{
    		var result = new List<int>();
    
    		using (var reader = new StreamReader(@"c:\test.txt"))
    		{
    			var readBuffer = new char[ReadBufferSize];
    
    			var buffer = new StringBuilder();
    
    			while ((reader.Read(readBuffer, 0, readBuffer.Length)) > 0)
    			{
    
    				foreach (char c in readBuffer)
    				{
    					if (!char.IsDigit(c))
    					{
    						// we found non digit character
    						int newInt;
    						if (int.TryParse(buffer.ToString(), out newInt))
    						{
    							result.Add(newInt);
    						}
    
    						buffer.Remove(0, buffer.Length);
    					}
    					else
    					{
    						buffer.Append(c);
    					}
    				}
    			}	
    
    			// check buffer
    			if (buffer.Length > 0)
    			{
    				int newInt;
    				if (int.TryParse(buffer.ToString(), out newInt))
    				{
    					result.Add(newInt);
    				}
    			}
    		}
    		
    		result.ForEach(Console.WriteLine);
    		Console.ReadKey();
    	}
    }
