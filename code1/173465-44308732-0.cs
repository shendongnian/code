    using System;
    class Test
    {
      static void Main()
      {
        float exact0 = (37 / 6); //6.1666e∞
        float exact1 = (37 % 6); //1
        float exact2 = (37 - (37 / 6) * 6); //0
        float exact3 = ((37 - (37 / 6)) * 6); //0
        float exact4 = (37 - ((37 / 6) * 6)); //185
        int a = 37;
        int b = 6;
        int c = 0;
        int d = a;
        int e = b;
        string Answer0 = "";
        string Answer1 = "";
        string Answer2 = "";
        string Answer0Alt = "";
        string Answer1Alt = "";
        string Answer2Alt = "";
        Console.WriteLine("37/6: " + exact0);
        Console.WriteLine("37%6: " + exact1);
        Console.WriteLine("(37 - (37 / 6) * 6): " + exact2);
        Console.WriteLine("((37 - (37 / 6)) * 6): " + exact3);
        Console.WriteLine("(37 - ((37 / 6) * 6)): " + exact4);
        Console.WriteLine("a: " + a + ", b: " + b + ", c: " + c + ", d: " + d + ", e: " + e);
        Console.WriteLine("Answer0: " + Answer0);
        Console.WriteLine("Answer0Alt: " + Answer0Alt);
        Console.WriteLine("Answer1: " + Answer1);
        Console.WriteLine("Answer0Alt: " + Answer1Alt);
        Console.WriteLine("Answer2: " + Answer2);
        Console.WriteLine("Answer2Alt: " + Answer2Alt);
        Console.WriteLine("Init Complete, starting Math...");
        Loop
        {
          if (a !< b) {
            a - b;
            c +1;}
          if else (a = b) {
            a - b;
            c +1;}
          else
          {
            String Answer0 = c + "." + a; //6.1
            //this is = to 37/6 in the fact that it equals 6.1 ((6*6=36)+1=37) or 6 remainder 1,
            //which according to my Calculator App is technically correct once you Round Down the .666e∞
            //which has been stated as the default behavior of the C# / Operand
            //for completion sake I'll include the alternative answer for Round Up also
            String Answer0Alt = c + "." + (a + 1); //6.2
            Console.WriteLine("Division Complete, Continuing...");
            Break
          }
        }
        string Answer1 = ((d - (Answer0)) * e); //185.4
        string Answer1Alt = ((d - (Answer0Alt​)) * e); // 184.8
        string Answer2 = (d - ((Answer0) * e)); //0.4
        string Answer2Alt = (d - ((Answer0Alt​) * e)); //-0.2
        Console.WriteLine("Math Complete, Summarizing...");
        Console.WriteLine("37/6: " + exact0);
        Console.WriteLine("37%6: " + exact1);
        Console.WriteLine("(37 - (37 / 6) * 6): " + exact2);
        Console.WriteLine("((37 - (37 / 6)) * 6): " + exact3);
        Console.WriteLine("(37 - ((37 / 6) * 6)): " + exact4);
        Console.WriteLine("Answer0: " + Answer0);
        Console.WriteLine("Answer0Alt: " + Answer0Alt);
        Console.WriteLine("Answer1: " + Answer1);
        Console.WriteLine("Answer0Alt: " + Answer1Alt);
        Console.WriteLine("Answer2: " + Answer2);
        Console.WriteLine("Answer2Alt: " + Answer2Alt);
        Console.Read();
      }
    }
