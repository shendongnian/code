	public class Program
	{
		public static void Main()
		{
			
			var input = new []
			{
				"(blue,(hmmm) derp)", 
			    "herpdediderp (orange,(hmm)) some other crap (red,hmm)"
			};
			
			foreach ( var s in input )
			{
    			var output = s.GetStuffInsideParentheses();
				foreach ( var o in output )
				{
	    		    Console.WriteLine(o);
				}
				Console.WriteLine();
			}
		}
	}
