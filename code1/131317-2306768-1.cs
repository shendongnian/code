    int i = 0;
    int count = 0;
    Console.WriteLine("Enter a number.");
    while (count <= 10)
    {
       i = Convert.ToInt32(Console.ReadLine());
       if (i > 1 && i < 10)
       {
           count++;
           continue;
           
       }
       if (i < 1 || i > 10)
       {
          Console.WriteLine("Enter New Number...");
          continue;
       }
    }
