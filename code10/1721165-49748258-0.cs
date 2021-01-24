    static void Main(string[] args)
    {
      int total = 0;
      int gt50Count = 0;
      for (int x = 1; x <= 5; x++)
      {
        Console.WriteLine("Enter your mark");
        int mark = int.Parse(Console.ReadLine());
        if (mark > 100 || mark < 0)
        {
          Console.WriteLine("Invalid mark,Enter your mark again");
          int newmark = int.Parse(Console.ReadLine());
          mark = newmark;
        }
    
        total += mark;
        if (mark >= 50)
        {
          gt50Count++;
        }
      }
      Console.WriteLine("sum = " + total);
      double average = (total / 5) * 1.00;
      Console.WriteLine("average = " + average);
      Console.WriteLine("Greather or equal to 50 count = " + gt50Count);
      Console.ReadLine();
    }
