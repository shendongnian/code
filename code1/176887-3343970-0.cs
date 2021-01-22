        static void Main(string[] args)
        {
            string s1 = "i have a car";
            string s2 = "i have a new car bmw";
            List<string> result;
            if (s2.Length > s1.Length)
            {
                result = s2.Split(' ').Except(s1.Split(' ')).ToList();
            }
            else
            {
                result = s1.Split(' ').Except(s2.Split(' ')).ToList();
            }
        }
