    class Program
    {
        static void Main(string[] args){
            string s = "some\n\tstring";
            string rez = Regex.Replace(s, @"\t|\r|\n", Match);
            Console.WriteLine(rez);
        }
        public static string Match(Match m)
        {
            string match = m.ToString();
            if(match.Equals("\t"))
            {
                return @"\t";
            }
            if (match.Equals("\r"))
            {
                return @"\r";
            }
            if (match.Equals("\n"))
            {
                return @"\n";
            }
            throw new NotSupportedException();
        }
    }
