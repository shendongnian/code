    using System;
    class ParameterTest
    {
     static void Mymethod(out int Param1)
     {
      Param1=100;
     }
     static void Main()
     {
      int Myvalue=5;
      MyMethod(Myvalue);
      Console.WriteLine(out Myvalue);             
     }
    }
