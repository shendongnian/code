     private static int GetInput(string v)
     {
         int intradius = 0;   //needs to be initialized to keep compiler happy
         while (true)
         {
             Console.Write($"{v}: ");
             string strradius = Console.ReadLine();
             if (!int.TryParse(strradius, out intradius))
             {
                 Console.WriteLine($"An integer is required: [{strradius}] is not an integer");
             }
             else if (intradius < 1)
             {
                 Console.WriteLine($"The entered number [{intradius}] is out of range, it must be one or greater");
             }
             else
             {
                 break;      //breaking out of the while loop, the input is good
             }
         }
         return intradius;
     }
