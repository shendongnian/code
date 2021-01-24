    using System;
    					
    public class Program
    {	
    	public static  int[] arrData = new int[5]{1,2,3,4,5};
    	
    	public static void Main()
    	{
    		Console.WriteLine("\nOriginal array\n");
    		foreach(var item in arrData)
    		{
    			Console.WriteLine(item.ToString());
    		}
    		Console.WriteLine("\nShift to last\n");
    		arrData = trololo(arrData);
    		foreach(var item in arrData)
    		{
    			Console.WriteLine(item.ToString());
    		}
    	}
    	
    	public static int[] trololo(int[] arr)
    	{
    		int last = arr[arr.Length - 1];
    		int first= arr[0];
    		arr[arr.Length - 1] = first;
    		arr[0] = last;
    		return arr;
    	}
    }
