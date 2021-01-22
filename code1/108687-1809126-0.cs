    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication3
    {
        class Program
        {
           static void Main(string[] args)
           {
               var input = "<b>The</b> <i>Man</i> on the <U><B>Moon</B></U>";
               var regex = new Regex("<.*?>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
               var output = regex.Replace(input, string.Empty);
               Console.WriteLine(output);
               Console.ReadLine();
          }
        }
}
