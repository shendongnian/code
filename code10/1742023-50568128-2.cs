      private static bool TryToLogin(int attempts = 5) {
        for (int attempt = 0; attempt < attempts; ++attempt) {
          Console.WriteLine("Enter username");
          string username = Console.ReadLine();
          Console.WriteLine("Enter password");
          string password = Console.ReadLine(); 
          if (username == "valid" && password == "valid) 
            return true;
        }
 
        return false;
      }
