    using System;
    using System.Collections.Generic;
    namespace CSharpDemos
    {
      class Program
      {
        static void Main(string[] args)
        {
          List<string> StringList = new List<string> { "Hello" };
          List<string> StringListRef = new List<string> { "Hallo" };
          AppendWorld(StringList);
          Console.WriteLine(StringList[0] + StringList[1]);
          HalloWelt(ref StringListRef);
          Console.WriteLine(StringListRef[0] + StringListRef[1]);
          CiaoMondo(out List<string> StringListOut);
          Console.WriteLine(StringListOut[0] + StringListOut[1]);
        }
        static void AppendWorld(List<string> LiStri)
        {
          LiStri.Add(" World!");
          LiStri = new List<string> { "Hallo", " Welt!" };
          Console.WriteLine(LiStri[0] + LiStri[1]);
        }
        static void HalloWelt(ref List<string> LiStriRef)
         { LiStriRef = new List<string> { LiStriRef[0], " Welt!" }; }
        static void CiaoMondo(out List<string> LiStriOut)
         { LiStriOut = new List<string> { "Ciao", " Mondo!" }; }
       }
    }
    /*Output:
    Hallo Welt!
    Hello World!
    Hallo Welt!
    Ciao Mondo!
    */
