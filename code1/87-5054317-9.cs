    class Program
    {
        static void Main(string[] args)
        {
            RunTest();
        }
        private static void RunTest()
        {
            DateTime birthDate = new DateTime(2000, 2, 28);
            DateTime laterDate = new DateTime(2011, 2, 27);
            string iso = "yyyy-MM-dd";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine("Birth date: " + birthDate.AddDays(i).ToString(iso) + "  Later date: " + laterDate.AddDays(j).ToString(iso) + "  Age: " + birthDate.AddDays(i).Age(laterDate.AddDays(j)).ToString());
                }
            }
            Console.ReadKey();
        }
    }
