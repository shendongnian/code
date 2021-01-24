    using PCRE;
    using System.Linq;
    namespace PCREdNET
    {
        class Program
        {
            static void Main(string[] args)
            {
                var marks = PcreRegex.Matches("bar", "(?|foo(*:1)|bar(*:2)|baz(*:3))")
                           .Select(m => m.Mark)
                           .ToList();
            }
        }
    }
