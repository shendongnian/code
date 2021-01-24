    for (int y = 0; y < array.GetLength(0); ++y) {
      if (y > 0)
        Console.WriteLine();
    
      for (int x = 0; x < array.GetLength(1); ++x) {
        if (x > 0) 
          Console.Write(";");   
    
        Console.Write(array[y, x]); 
      }
    }
