        static void Main(string[] args)
        {
            Console.WriteLine(DoTheMrBlah("[blahField] [int] NOT NULL,"));
            Console.ReadKey();
        }
        static string DoTheMrBlah(string mrBlahMe)
        {
            Match m = Regex.Match(mrBlahMe, @"\[([a-z]){1}([a-zA-Z0-9]+)\](.+)");
            if (m.Success)
            {
                char upperme = m.Groups[1].Value.ToUpper()[0];
                return string.Format("[{0}{1}]{2}", upperme, m.Groups[2], m.Groups[3]);
            }
            else return mrBlahMe;
        }
