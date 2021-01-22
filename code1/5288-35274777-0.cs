     private static int _flag = 0;
     private static int _value = 0;
     var t1 = Task.Run(() =>
     {
         _value = 10; /* compiler could switch these lines */
         _flag = 5;
     });
     var t2 = Task.Run(() =>
     {
         if (_flag == 5)
         {
             Console.WriteLine("Value: {0}", _value);
         }
         else
         {
             Console.WriteLine("Order of statements was changes by compiler.");
         }
     });
