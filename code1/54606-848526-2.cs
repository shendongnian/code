    // statements_switch.cs
    using System;
    class SwitchTest 
    {
       public static void Main()  
       {
          Console.WriteLine("Coffee sizes: 1=Small 2=Medium 3=Large"); 
          Console.Write("Please enter your selection: "); 
          string s = Console.ReadLine(); 
          int n = int.Parse(s);
          int cost = 0;
          switch(n)       
          {         
             case 1:   
                cost += 25;
                break;                  
             case 2:            
                cost += 25;
                goto case 1;           
             case 3:            
                cost += 50;
                goto case 1;             
             default:            
                Console.WriteLine("Invalid selection. Please select 1, 2, or3.");            
                break;      
           }
           if (cost != 0)
              Console.WriteLine("Please insert {0} cents.", cost);
           Console.WriteLine("Thank you for your business.");
       }
    }
