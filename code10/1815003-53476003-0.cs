    using System;
    using System.Collections.Generic;
    namespace Exercise_9
    {
       class Program
       {
         static void Main(string[] args)
         {
		    HashSet<int> A = new HashSet<int>();
            HashSet<int> B = new HashSet<int>();
            //put some stuff in the sets
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                A.Add(r.Next(4));
                B.Add(r.Next(12));
            }
            //display each set and the union
            Console.WriteLine("Values in A are: ");
            foreach (var value in A) {
            	Console.WriteLine(value);
            }
            
            Console.WriteLine("Values in B are: ");
            foreach (var value in B) {
            	Console.WriteLine(value);
            }
            
            HashSet<int> C = A;
            // storing union in set C using UnionWith
            C.UnionWith(B);
			
			Console.WriteLine("Values in union set - C are: ");
			foreach (var value in C) {
            	Console.WriteLine(value);
            }
			
            Console.WriteLine("After union operation");
            
            Console.WriteLine("Values in A are: ");
            foreach (var value in A) {
            	Console.WriteLine(value);
            }
            
            Console.WriteLine("Values in B are: ");
            foreach (var value in B) {
            	Console.WriteLine(value);
            }
	    }
     }
