    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
    	public class Program
    	{
    		public static void Main(string[] args)
    		{
    			int[] intArr = new int[5] { 1, 2, 3, -1, 0 };
    			int result =  intArr.AsParallel().Where(i => i > 0).Sum();
    			Console.WriteLine("The total sum of the array is: {0}", result);
    		}
    	}
    }
