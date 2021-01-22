      Console.WriteLine("Enter two Numbers");
      int Num1 = 0 ,Num2 = 0 ;
      Match M = Regex.Match(Console.ReadLine(),@"(\d+) (\d+)");
      Num1 = int.Parse(M.Groups[1].Value);
      Num2 = int.Parse(M.Groups[2].Value);
      //Using Split 
      Console.WriteLine("Enter two Numbers");
      string[] Ints = (Console.ReadLine().Split(' '));
      Num1 = int.Parse(Ints[0]);
      Num2 = int.Parse(Ints[1]);
