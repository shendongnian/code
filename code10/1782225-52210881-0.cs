    class Program
    {
        enum CharState
        {
            Add,
            Equal,
            Remove
        }
        struct CharResult
        {
            public char c;
            public CharState state;
        }
        static void Main(string[] args)
        {
            string a = "asdfghjk";
            string b = "wsedrftr";
            while (true)
            {
                Console.WriteLine("Enter string a (enter to quit) :");
                a = Console.ReadLine();
                if (a == string.Empty)
                    break;
                Console.WriteLine("Enter string b :");
                b = Console.ReadLine();
                List<CharResult> result = calculate(a, b);
                DisplayResults(result);
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadLine();
        }
        static List<CharResult> calculate(string a, string b)
        {
            List<CharResult> res = new List<CharResult>();
            int i = 0, j = 0;
            char[] array_a = a.ToCharArray();
            char[] array_b = b.ToCharArray();
            while (i < array_a.Length && j < array_b.Length)
            {
                //For the current char in a, we check for the equal in b
                int index = b.IndexOf(array_a[i], j);
                if (index < 0) //not found, this char should be removed
                {
                    res.Add(new CharResult() { c = array_a[i], state = CharState.Remove });
                    i++;
                }
                else
                {
                    //we add all the chars between B's current index and the index
                    while (j < index)
                    {
                        res.Add(new CharResult() { c = array_b[j], state = CharState.Add });
                        j++;
                    }
                    //then we say the current is the same
                    res.Add(new CharResult() { c = array_a[i], state = CharState.Equal });
                    i++;
                    j++;
                }
            }
            while (i < array_a.Length)
            {
                //b is now empty, we remove the remains
                res.Add(new CharResult() { c = array_a[i], state = CharState.Remove });
                i++;
            }
            while (j < array_b.Length)
            {
                //a has been treated, we add the remains
                res.Add(new CharResult() { c = array_b[j], state = CharState.Add });
                j++;
            }
            return res;
        }
        static void DisplayResults(List<CharResult> results)
        {
            foreach (CharResult r in results)
            {
                Console.WriteLine($"'{r.c}' - {r.state}");
            }
        }
    }
