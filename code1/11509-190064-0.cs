    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Temp
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			int[] array = { 1, 2, 3, 4 };
    			int[] array2 = new int[40];
    
    			for (int i = 0; i < array2.Length; i += array.Length)
    			{
    				Array.Copy(array, i % array.Length, array2, i, array.Length);
    			}
    
    			int count = 0;
    			foreach (int i in array2)
    			{
    				Console.Write(i.ToString() + " " + (count++).ToString() + "\n");
    			}
    
    			Console.Read();
    		}
    	}
    }
:)
