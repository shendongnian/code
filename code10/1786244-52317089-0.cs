    using System;
    using System.Linq;
    
    namespace IdentifyIATA
    {
        public static class Iata
        {
            public static Tuple<string,string> CodeIdentifier(string code)
            {
                var first = code.Substring(0, 3);
                if (first.All(char.IsLetter)){
                    return new Tuple<string, string>(first, code.Substring(3));
                }
                return new Tuple<string, string>(code.Substring(0, 2), code.Substring(3));
            }
        }
    }
