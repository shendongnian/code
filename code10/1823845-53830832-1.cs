        for (int i = 0; i < mas.GetLength(0); ++i) { 
          for (int j = 0; j < mas.GetLength(1); ++j) {
            Console.Write(mas[i, j]);
            Console.Write(' '); // <- delimiter between columns
          }
          Console.WriteLine();  // <- delimiter between lines
        }
