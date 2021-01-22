      static void Main(string[] args)
      {
         int myInteger = 42;
         decimal myDecimal = 3.141592653589793238M;
         long myLong = 900000000000;
         byte myByte = 128;
         float myFloat = 2.71828F;
         TestFunction(myInteger);
         TestFunction(myDecimal);
         TestFunction(myLong);
         TestFunction(myByte);
         TestFunction(myFloat);
      }
      static void TestFunction(System.ValueType number)
      {
         Console.WriteLine(number.ToString());
      }
