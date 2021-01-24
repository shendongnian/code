    Dictionary<int, int[]> test = new Dictionary<int, int[]>();
    int lineCount = 1;
    while ((line = file.ReadLine()) != null && line.Length > 10)
       {
          int[] intArray = new int[3];
          line.Trim();
          string[] parts = line.Split(' ');
          for (int i = 0; i < 3; i++)
              {
                   intArray[i] = int.Parse(parts[i]);
              }
          test[lineCount] = intArray;
          lineCount++;
                    
      }
