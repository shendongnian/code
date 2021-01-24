    if (i == 0) {
      Test0(); //Test0 = 12
      Console.WriteLine("Test0 = " + i.ToString());
    } else...   
    private static void Test0() {
      int result = 0;
      for (int i = 1; i <= 3; i++) {
        for (int j = 1; j <= 2; j++) {
          result += i;
        }
      }
      Console.WriteLine("Test0 = " + result.ToString());
    }
