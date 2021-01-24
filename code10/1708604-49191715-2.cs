    .OrderBy(x => x.SortKeyColor, new ColorNameComparer())
--------
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Globalization;
    namespace ConsoleApp
    {
        public class Program
        {
            public static void Main()
            {
                string file =
                    "1;1.5;BK;200;PAN5A;PAN5B;ABC\r\n" +
                    "2;0.75;BK;620;PAN3A;PAN3A;ACC\r\n" +
                    "3;2;RD;150;PAN2A;PAN2A;AAA\r\n" +
                    "4;1.5;BL;500;PAN2A;PAN2A;ABB\r\n" +
                    "5;0.75;GY;250;PAN1A;PAN2A;AAA\r\n" +
                    "6;5.25;GY;200;PAN3A;PAN3B;CCC\r\n" +
                    "7;1.25;BU;150;PAN4A;PAN4A;DDD\r\n" +
                    "8;0.75;BK;800;PAN4A;PAN4A;BBB";
                string[] lines = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var sorted = lines.Select(line => new
                    {
                        SortKeyColor = line.Split(';')[2],
                        SortKeySection = double.Parse(line.Split(';')[1], CultureInfo.InvariantCulture),
                        SortKeyLenght = int.Parse(line.Split(';')[3]),
                        Line = line
                    }
                ).OrderBy(x => x.SortKeyColor, new ColorNameComparer()).ThenBy(x => x.SortKeySection).ThenBy(x => x.SortKeyLenght).Select(x => x.Line);
                foreach (var entry in sorted)
                    Console.WriteLine(entry);
            }
        }
        public class ColorNameComparer : IComparer<string>
        {
            private readonly List<string> colorOrder = new List<string> {"GY", "BL", "RD"};
            public int Compare(string x, string y)
            {
                if (x == y)
                    return 0;
                if (x == "BK")
                    return 1;
                if (y == "BK")
                    return -1;
                if (colorOrder.Contains(x) && colorOrder.Contains(y))
                    return colorOrder.IndexOf(x) > colorOrder.IndexOf(y) ? 1 : -1;
                if (colorOrder.Contains(x))
                    return -1;
                if (colorOrder.Contains(y))
                    return 1;
                return String.Compare(x, y, StringComparison.Ordinal);
            }
        }
    }
    
