    static void Main(string[] args)
        {
            string test = " Mimi loves Toto and Tata hate Mimi so Toto killed Tata";
            foreach (string j in test.Split(' '))
            {
                if (j.Length > 0)
                {
                    if (j.ToUpper()[0] == j[0])
                    {
                        Console.WriteLine(j);
                    }
                }
            }
            Console.ReadKey(); //Press any key to continue;
        }
