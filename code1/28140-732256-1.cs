    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<string> list = new List<string>(new string[] { "abcde", "abcd", "abc"/*will break length constraint*/, "ab", "a" });
    			//Uncomment line below to see non-lazy behavior.  All items converted before method returns, and will fail on third item, which breaks the length constraint.
    			//List<ConstrainedString> constrained_list = list.ConvertAll<string,ConstrainedString>();
    			IEnumerable<ConstrainedString> constrained_list = list.ConvertAll<string,ConstrainedString>( true ); //lazy conversion; conversion is not attempted until that item is read
    			foreach (ConstrainedString constrained_string in constrained_list) //will not fail until the third list item is read/converted
    				System.Console.WriteLine( constrained_string.ToString() );
    		}	
    
    		public class ConstrainedString
    		{
    			private readonly string value;
    			public ConstrainedString( string value ){this.value = Constrain(value);}
    			public string Constrain( string value ) {
    				if (value.Length > 3) return value;
    				throw new ArgumentException("String length must be > 3!");
    			}
    			public static explicit operator ConstrainedString( string value ){return new ConstrainedString( value );}
    			public override string ToString() {return value;}
    		}
    	}
    }
