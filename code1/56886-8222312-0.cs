    using System;
    class demo
    {
         static void Main()
         {
           int number;
           Console.WriteLine("Enter Number you Should be Checked Number is Prime or not Prime");
           number = Int32.Parse(Console.ReadLine());
           for(int i =2;i<number/2;i++)
           {
                 if(number % i == 0)
                 {
                   Console.WriteLine("Entered number is not Prime");
                    break;
                 }
           }
           if(number % i !=0)
           {
              Console.WriteLine("Entered Number is Prime");
           }
    
           Console.ReadLine();
         }
    }
