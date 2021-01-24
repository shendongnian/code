        class Program
        {
            static void Main(string[] args)
            {
    			var myWackyList = new object[] {
    				new[]{1d, 2d},
    				3d,
    				new[]{4d, 5d},
    				new []
    				{
    					new[]
    					{
    						6d
    					}
    				},
    				"7",
    				new[]{ "8", "9"}
    			};
    
    			Console.WriteLine( string.Join(", ", Flatten( myWackyList )));
    		}
    
    		static IEnumerable<object> Flatten(IEnumerable enumerable)
    		{
    			foreach (var val in enumerable)
    			{
    				if ( val.GetType().IsArray )
    					foreach ( var flattenedVal in Flatten( val as IEnumerable ) )
    						yield return flattenedVal;
    				else
    					yield return val;
    			}
    		}
    	}
