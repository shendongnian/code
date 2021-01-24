    using System;
    public class Program
    {
        public static void Main()
        {
            int[] a = {3, 4, 0, 5, 2, 3};
            int N = 6;
            int min_index = 0; 
            bool found = false;
            int index = -1;
            int i = 0;
            while(i < N && !found)
            {
    			
                if(a[i] >= N) 
                    index = a[i] % N;
                else
                    index = a[i];
                
                if(a[index] >= N) //its a duplicated elements 
                {
                    min_index = i;
    				found = true;
                }else
                {
    				a[index] += N;
                }
    			i++;
    			
            }
    
            Console.WriteLine("Result = " + a[min_index] % N);
        }
    }
   
