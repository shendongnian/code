        using System;
        					
        public class Program
        {
        	public static void Main()
        	{
        		bool greater = false;
        		Console.WriteLine("Enter your name: ");
        		string userName3 = Console.ReadLine();
        		while (greater == false)
        			{
           				if (userName3.Length >= 5)
           					{
              					greater = true;
           					}
           				else
           					{
              					Console.WriteLine("The name must be 5 characters or more");
           					}
        			}
    //Indexing to string is used to get letters from string
        			Console.WriteLine(userName3[0] + " " + userName3[2] + " " + userName3[4]);
        	}
        }
