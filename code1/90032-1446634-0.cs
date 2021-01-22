    class Program {
        static void Main(string[] args) {
            var d = new Dictionary<string, string> { { "Name", "World" } };
            var t = new Test();
            Console.WriteLine(t.Replace("Hello {Name}", d));
            Console.WriteLine(t.Replace("Hello {{Name}}", d));
            Console.WriteLine(t.Replace("Hello {{{Name}}}", d));
            Console.WriteLine(t.Replace("Hello {{{{Name}}}}", d));
            Console.ReadKey();
        }
    }
    class Test {
        private Regex MatchNested = new Regex(
            @"\{ (?>
                    ([^{}]+)
                  | \{ (?<D>)
                  | \} (?<-D>)
                  )*
                  (?(D)(?!))
               \}",
                 RegexOptions.IgnorePatternWhitespace
               | RegexOptions.Compiled 
               | RegexOptions.Singleline);
        public string Replace(string input, Dictionary<string, string> vars) {
            Matcher matcher = new Matcher(vars);
            return MatchNested.Replace(input, matcher.Replace);
        }
        private class Matcher {
            private Dictionary<string, string> Vars;
            
            public Matcher(Dictionary<string, string> vars) {
                Vars = vars;
            }
            public string Replace(Match m) {
                string name = m.Groups[1].Value;
                int length = (m.Groups[0].Length - name.Length) / 2;
                string inner = (length % 2) == 0 ? name : Vars[name];
                return MakeString(inner, length / 2);
            }
            private string MakeString(string inner, int braceCount) {
                StringBuilder sb = new StringBuilder(inner.Length + (braceCount * 2));
                sb.Append('{', braceCount);
                sb.Append(inner);
                sb.Append('}', braceCount);
                return sb.ToString();
            }
        
        }
    }
