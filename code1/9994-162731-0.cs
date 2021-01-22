    class Program
    {
        static void Main(string[] args)
        {
            string email = "\"Jimbo\" <jim@example.com>";
            Console.WriteLine(parseEmail(email));
        }
        private static string parseEmail(string inputString)
        {
            Regex r = 
                new Regex(@"^((?:(?:(?:[a-zA-Z0-9][\.\-\+_]?)*)[a-zA-Z0-9])+)\@((?:(?:(?:[a-zA-Z0-9][\.\-_]?){0,62})[a-zA-Z0-9])+)\.([a-zA-Z0-9]{2,6})$");
            string[] tokens = inputString.Split(' ');
            foreach (string s in tokens)
            {
                string temp = s;
                temp = temp.TrimStart('<'); temp = temp.TrimEnd('>');
                
                if (r.Match(temp).Success)
                    return temp;
            }
            throw new ArgumentException("Not an e-mail address");
        }
    }
