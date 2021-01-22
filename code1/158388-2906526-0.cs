    // Compile with
    // csc Test.cs /r:FirstAlias=First.dll /r:SecondAlias=Second.dll
    extern alias FirstAlias;
    extern alias SecondAlias;
    
    using System;
    using FD = FirstAlias::Demo;
    class Test
    {
       static void Main()
       {
          Console.WriteLine(typeof(FD.Example)); 
          Console.WriteLine(typeof(SecondAlias::Demo.Example));
       }
    }
