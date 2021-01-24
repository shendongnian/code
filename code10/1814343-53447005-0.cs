    static void Main(string[] args)
        {
            var numOrg = 2;
            var percentage = 0.3;
            var result = (double)numOrg;
            while (numOrg <= 10)
            {
                result += percentage * result;
                Console.WriteLine($"{numOrg}: {result}");
                numOrg++;
            }
            Console.ReadKey();
        }
