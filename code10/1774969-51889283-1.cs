     int input = int.Parse(Console.ReadLine());
     // This will create an input with the amount of spaces inserted by the user
     int[] A = new int[input];
    
      for (int i = 1; i <= input; i++)
      {
           // This will prevent any errors for having a decimal
           A[i - 1] = int.Parse(Math.Round(1 / i * i));
           Console.WriteLine(A[i - 1]);    
      }
