    StringBuilder sb = new StringBuilder();
    for (int y = 0; y < array.GetLength(0); ++y) {
      if (y > 0)
        sb.AppendLine();
    
      for (int x = 0; x < array.GetLength(1); ++x) {
        if (x > 0) 
          sb.Append(";");   
    
        sb.Append(array[y, x]); 
      }
    }
    string result = sb.ToString();
    ...
    Console.Write(result);
