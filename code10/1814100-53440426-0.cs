    public static List<List<string>> PairedCases = new List<List<string>>();
        public static void addsubstrin(string money, string casenom)
        {
            List<string> sublist = new List<string>();
            sublist.Add(money);
            sublist.Add(casenom);
            PairedCases.Add(sublist);
        }
        static void Main(string[] args)
        {
            int[] cashPrizeArray = new int[] { 0, 1, 2, 5, 10, 20, 50, 100, 150, 200, 250, 500, 750, 1000, 2000, 3000, 4000, 5000, 10000, 15000, 20000, 25000, 50000, 75000, 100000, 200000 };
            string[] caseArray = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26" };
            Random rnd = new Random();
            foreach (int inte in cashPrizeArray)
            {
                Restart:;
                int putincase = rnd.Next(1, 27);
                bool found = false;
                //here we chack if its already in the list
                for (int a = 0; a < PairedCases.Count(); a++)
                {
                    if (putincase.ToString() == PairedCases[a][1])
                    {
                        found = true;
                    }
                }
                if(found == false)
                {
                    addsubstrin(inte.ToString(), putincase.ToString());
                }
                else
                {
                    goto Restart;
                }
            }
            for (int i = 0; i < PairedCases.Count(); i++)
            {
                Console.WriteLine(PairedCases[i][0] + "   " + PairedCases[i][1]);
            }
            Console.ReadLine();
        }
