     int input = int.Parse(Console.ReadLine());
     // This will create an input with the amount of spaces inserted by the user
     int[] A = new int[input];
    
      for (int i = 1; i <= input; i++)
      {
           A[i - 1] = (1 / i * i);
           Console.WriteLine(A[i - 1]);    
      }
