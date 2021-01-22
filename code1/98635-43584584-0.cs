6.01
6.03
6.04
6#04
 var output = input.OrderBy(s => s, new NaturalStringComparer());
            foreach (var sort in output)
            {
                Console.WriteLine(sort);
            }
public struct NaturalStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            int lx = x.Length, ly = y.Length;
            int a = int.Parse(System.Text.RegularExpressions.Regex.Replace(x, @"\D+", ""));
            int b = int.Parse(System.Text.RegularExpressions.Regex.Replace(y, @"\D+", ""));
            return a.CompareTo(b);
        }
    }
