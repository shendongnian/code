    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication3
    {
      class Program
      {
        static void Main(string[] args)
        {
          Regex exp = new Regex(@"WDL FRM CHK(\s)+[1-9,]+(\s)+(?<approvals>[1-9,]+)(\s)+");
          string str = "WDL FRM CHK   236   1,854   45,465  123     3";
          Match match = exp.Match(str);
          if (match.Success)
          {
    	    Console.WriteLine("Approvals: " + match.Groups["approvals"].Value);
          }
          Console.ReadLine();
        }
      }
    }
