    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                 List<int> listofint1 = new List<int> { 4, 8, 4, 1, 1, 4, 8 };
               List<int> updatedlist= removeduplicate(listofint1);
                foreach(int num in updatedlist)
                   Console.WriteLine(num);
            }
    		
    		
    		public static List<int> removeduplicate(List<int> listofint)
       		 {
       			 List<int> listofintwithoutduplicate= new List<int>();
       
    
       			  foreach(var num in listofint)
           			 {
            		  if(!listofintwithoutduplicate.Any(p=>p==num))
    						{
    						  listofintwithoutduplicate.Add(num);
    						}
          			  }
       			 return listofintwithoutduplicate;
       		 }
        }
        
    
      
    }
