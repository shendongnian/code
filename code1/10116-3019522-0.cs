    // Assembly1.cs
    // compile with: /target:library
    internal class BaseClass 
    {
       public static int intM = 0;
    }
    // Assembly1_a.cs
    // compile with: /reference:Assembly1.dll
    class TestAccess 
    {
       static void Main()
       {  
          BaseClass myBase = new BaseClass();   // CS0122
       }
    }
