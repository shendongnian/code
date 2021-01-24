    using System;
    using System.Collections.Generic;
    using System.IO;
    public class Solution
    {
		public int Factorial(int input)
		{
			int result = 1;
			
			for (int i = 1; i <= input; i++)
			{
			    result = result * i;
			}
			
			return result;
		}
    }
