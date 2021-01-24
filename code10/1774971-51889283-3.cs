     int input = int.Parse(Console.ReadLine());
     // This will create an input with the amount of spaces inserted by the user
     int[] A = new int[input];
    
      for (int i = 1; i <= input; i++)
      {
           // This will prevent any errors for having a decimal if the operation of (1 / i * i) is modified to a custom one which wouldn't return an int.
           A[i - 1] = Convert.ToInt32(Math.Round(1 / i * i));
           Console.WriteLine(A[i - 1]);    
      }
