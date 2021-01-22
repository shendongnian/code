    using System;
    using System.Runtime.InteropServices;
       public static void SayHello([Optional][DefaultParameterValue("Hello Universe!")] string s)
       {
          Console.WriteLine(s);
       }
