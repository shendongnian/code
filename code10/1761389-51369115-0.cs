    namespace Like
    {
        class Program
        {
            static bool Is(char a, char b)
            { 
                  return a == b || 
                  char.ToUpper(a) == b || 
                  char.ToUpper(b) == a;
            }
            static bool IsLike(string sample, string query)
            {
                int k = 0;
                foreach (char c in sample)
                {
                    if (!Is(c, query[k]))
                    {
                        k = 0;
                        continue;
                    }
                    if (++k == query.Length)
                        return true;
                }
                return false;
            }
            static void Main(string[] args)
            {
                string testSample = "This is a str1ng 0f charac7er5";
                Console.WriteLine(IsLike(testSample, "this"));
                Console.WriteLine(IsLike(testSample, "of"));
                Console.WriteLine(IsLike(testSample, "chAra"));
                Console.ReadKey();
            }
        }
    }
