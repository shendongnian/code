    using System;
    using System.Linq;
    using System.IO;
    using System.Globalization;
    
    namespace SO2593168
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = File.ReadAllLines("A.txt");
                var b =
                    (from line in File.ReadAllLines("B.txt")
                     let parts = line.Split('|')
                     select new { key = parts[0], value = parts[1] });
    
                var comparer = StringComparer.Create(CultureInfo.InvariantCulture, true);
                var result =
                    from key in a
                    from keyvalue in b
                    where comparer.Compare(keyvalue.key, key) == 0
                    group keyvalue.value by keyvalue.key into g
                    select new { g.Key, values = String.Join("|", g.ToArray()) };
    
                foreach (var entry in result)
                    Console.Out.WriteLine(entry.Key + "|" + entry.values);
            }
        }
    }
