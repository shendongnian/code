        static void Main()
        {
            string choice = "y";
            do
            {
                try
                {
                    Console.WriteLine("Enter word :");
                    string abc = Console.ReadLine().ToString();
                    Console.WriteLine("Combinatins for word :");
                    List<string> final = comb(abc);
                    int count = 1;
                    foreach (string s in final)
                    {
                        Console.WriteLine("{0} --> {1}", count++, s);
                    }
                    Console.WriteLine("Do you wish to continue(y/n)?");
                    choice = Console.ReadLine().ToString();
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                }
            } while (choice == "y" || choice == "Y");
        }
        static string swap(string test)
        {
            return swap(0, 1, test);
        }
        static List<string> comb(string test)
        {
            List<string> sec = new List<string>();
            List<string> first = new List<string>();
            if (test.Length == 1) first.Add(test);
            else if (test.Length == 2) { first.Add(test); first.Add(swap(test)); }
            else if (test.Length > 2)
            {
                sec = generateWords(test);
                foreach (string s in sec)
                {
                    string init = s.Substring(0, 1);
                    string restOfbody = s.Substring(1, s.Length - 1);
                    List<string> third = comb(restOfbody);
                    foreach (string s1 in third)
                    {
                        if (!first.Contains(init + s1)) first.Add(init + s1);
                    }
                }
            }
            return first;
        }
        static string ShiftBack(string abc)
        {
            char[] arr = abc.ToCharArray();
            char temp = arr[0];
            string wrd = string.Empty;
            for (int i = 1; i < arr.Length; i++)
            {
                wrd += arr[i];
            }
            wrd += temp;
            return wrd;
        }
        static List<string> generateWords(string test)
        {
            List<string> final = new List<string>();
            if (test.Length == 1)
                final.Add(test);
            else
            {
                final.Add(test);
                string holdString = test;
                while (final.Count < test.Length)
                {
                    holdString = ShiftBack(holdString);
                    final.Add(holdString);
                }
            }
            return final;
        }
        static string swap(int currentPosition, int targetPosition, string temp)
        {
            char[] arr = temp.ToCharArray();
            char t = arr[currentPosition];
            arr[currentPosition] = arr[targetPosition];
            arr[targetPosition] = t;
            string word = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                word += arr[i];
            }
         
            return word;
 
        }
    }
