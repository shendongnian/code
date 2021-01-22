    // Assembly2.cs
    // compile with: /target:library
    public class BaseClass 
    {
       internal static int intM = 0;
    }
    // Assembly2_a.cs
    // compile with: /reference:Assembly1.dll
    public class TestAccess 
    {
       static void Main() 
       {      
          BaseClass myBase = new BaseClass();   // Ok.
          BaseClass.intM = 444;    // CS0117
       }
    }
