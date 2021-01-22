    //apart from regex we can also use this
    string input = Console.ReadLine();
                char[] a = input.ToCharArray();
                char[] b = new char[a.Length];
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(a[i]))
                    {
                        b[count] = a[i];
                        count++;
                    }
                }
                Array.Resize(ref b, count);
                foreach(var items in b)
                {
                    Console.WriteLine(items);
                }
                Console.ReadLine();
    //it will display the special characters in the string input
