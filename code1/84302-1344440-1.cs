namespace ConsoleApplication2
{
    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            Random adomRng = new Random();
            string rndString = string.Empty;
            char c;
            for (int i = 0; i &lt; 8; i++)
            {
                while (!Regex.IsMatch((c=Convert.ToChar(adomRng.Next(48,128))).ToString(), "[A-Za-z0-9]"));
                rndString += c;
            }
            Console.WriteLine(rndString + Environment.NewLine);
        }
    }
}
