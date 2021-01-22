    Prompter.getString("Name ? ", ref firstName);
    Prompter.getString("Lastname ? ", ref lastName);
    Prompter.getString("Birthday ? ", ref firstName);
    Prompter.getInt("Id ? ", ref id);
    Prompter.getChar("Id type: <n = national id, p = passport, d = driver licence, m = medicare> \n? ", ref c);
    public static class Prompter
    {
        public static void getKey(string msg, ref string key)
        {
            Console.Write(msg);
            ConsoleKeyInfo cki = Console.ReadKey();
            string k = cki.Key.ToString();
            if (k.Length == 1)
                key = k;
        }
        public static void getChar(string msg, ref char key)
        {
            Console.Write(msg);
            key = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }
        public static void getString(string msg, ref string s)
        {
            Console.Write(msg);
            string input = Console.ReadLine();
            if (input.Length != 0)
                s = input;
        }
        public static void getInt(string msg, ref int i)
        {
            int result;
            string s;
            Console.Write(msg);
            s = Console.ReadLine();
            int.TryParse(s, out result);
            if (result != 0)
                i = result;       
        }
        // not implemented yet
        public static string getDate(string msg)
        {
            // I should use DateTime.ParseExact(dateString, format, provider);
            throw new NotImplementedException();
        }    
    }
