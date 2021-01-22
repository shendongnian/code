    public static void DrawGrid(int grid) {
       string display = " 12345678";
       for (int i = 9; i > 0; i--) {
          Console.Write("{0}{1}", display[grid % i], i % 3 == 1 ? "\r\n" : "");
          display = display.Remove(grid % i, 1);
          grid /= i;
       }
    }
