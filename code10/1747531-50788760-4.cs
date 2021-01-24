    if (i == 5) {
      Test5(i);
      Test5(i - 2);
    } else...
    private static void Test5(int i) {
      Program.value -= i; //value = 0
      Console.WriteLine("Test5 = " + Program.value.ToString());
    }
