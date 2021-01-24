      static int ReadInt(string title) {
        int result = 0;
        while (true) {
          Console.WriteLine(title);
          if (int.TryParse(Console.ReadLine(), out result)) 
            return result;
          Console.WriteLine("Invalid number. Please make it an integer... e.g 1-9");
        }
      }
