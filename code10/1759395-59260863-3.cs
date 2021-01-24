    using System;
    using System.Text.RegularExpressions;
                        
    public class Program
    {
        public static void Main()
        {
            var u1 = new Urn("URN:foo:a123,456");
            var u2 = new Urn("urn:foo:a123,456");
            var u3 = new Urn("urn:foo:a123,456");
            var u4 = new Urn("urn:FOO:a123,456");
            var u5 = new Urn("urn:not-this-one:a123,456");
            Console.WriteLine(u1 == u2); // True
            Console.WriteLine(u3 == u4); // True
            Console.WriteLine(u4 == u5); // False
        }
        public class Urn : Uri
        {
            public const string UrnScheme = "urn";
            private const RegexOptions UrnRegexOptions = RegexOptions.Singleline | RegexOptions.CultureInvariant;
            private static Regex UrnRegex = new Regex("^urn:(?<NID>[a-z|A-Z][a-z|A-Z|-]{0,30}[a-z|A-Z]):(?<NSS>.*)$", UrnRegexOptions);
            public string NID { get; }
            public string NSS { get; }
            public Urn(string s) : base(s, UriKind.Absolute)
            {
                if (this.Scheme != UrnScheme) throw new FormatException($"URN scheme must be '{UrnScheme}'.");
                var match = UrnRegex.Match(this.AbsoluteUri);
                if (!match.Success) throw new FormatException("URN's NID is invalid.");
                NID = match.Groups["NID"].Value;
                NSS = match.Groups["NSS"].Value;
            }
            public override bool Equals(object other)
            {
                if (ReferenceEquals(other, this)) return true;
                return
                    other is Urn u &&
                    string.Equals(NID, u.NID, StringComparison.InvariantCultureIgnoreCase) &&
                    string.Equals(NSS, u.NSS, StringComparison.Ordinal);
            }
            public override int GetHashCode() => base.GetHashCode();
            public static bool operator == (Urn u1, Urn u2)
            {
                if (ReferenceEquals(u1, u2)) return true;
                if (ReferenceEquals(u1, null) || ReferenceEquals(u2, null)) return false;
                return u1.Equals(u2);
            }
            public static bool operator != (Urn u1, Urn u2)
            {
                if (ReferenceEquals(u1, u2)) return false;
                if (ReferenceEquals(u1, null) || ReferenceEquals(u2, null)) return true;
                return !u1.Equals(u2);
            }
        }
    }
