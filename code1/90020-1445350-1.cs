      static void Main(string[] args)
        {
            var str = "<something><or><other>";
            var re = new Regex(@"(\w+)");
            MatchCollection mc = re.Matches(str);
            foreach (Match m in mc)
            {
                Console.WriteLine(m.Value);
            }
        }
