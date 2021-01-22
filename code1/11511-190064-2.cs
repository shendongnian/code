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
    			int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
    			int[] array2 = new int[213];
    
    			for (int i = 0; i < array2.Length; i += array.Length)
    			{
    				int length = array.Length;
    				if ((i + array.Length) >= array2.Length)
    					length = array2.Length - i;
    				Array.Copy(array, 0, array2, i, length);
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
