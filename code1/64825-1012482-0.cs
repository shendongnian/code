    void addition(int a, int b, out int result, ref int count)
    {
      result = a + b;
      count ++;
    }
    void static main()
    {
      int opCount = 0;  // need initialization
      int opResult;     // don't need initialization
      addition(5, 4, out opResult, ref opCount);
      Console.WriteLine("5 + 4 = {0}", opResult); // display "5 + 4 = 9"
      addition(2, 3, out opResult, ref opCount);
      Console.WriteLine("2 + 3 = {0}", opResult); // display "2 + 3 = 5"
      Console.WriteLine("Operation count : {0}", opCount); // display "Operation count : 2"
    }
