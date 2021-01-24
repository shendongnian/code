        using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int[] a = {3, 4, 2, 5, 2, 3};
    		int N = 6;
    		int min_index = N-1; 
    		for(int i = 0; i < N; i++)
    		{
    			if(a[Math.Abs(a[i])] < 0 || a[Math.Abs(a[i])] == -N+1) //its a duplicated elements 
    			{
    				if(i < min_index) //store the lower index of repeated elements
    				{
    					min_index = i;
    				}
    			}else
    			{
    				if(a[Math.Abs(a[i])] > 0)
    				{
    					a[Math.Abs(a[i])] = -a[Math.Abs(a[i])];
    				}else
    				{
    					a[Math.Abs(a[i])] += -N+1;
    				}
    			}
    		}
    		
    		Console.WriteLine("Result = " + Math.Abs(a[min_index]));
    	}
    }
