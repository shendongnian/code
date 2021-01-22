        public static string GetMostPopular(ArrayList vals)
        {
            IDictionary<string, int> dict = new Dictionary<string, int>();
            int mx = 0;
            string ret = "";
            foreach (string x in vals)
            {
                if (!dict.ContainsKey(x))
                {
                    dict[x] = 1;
                }
                else
                {
                    dict[x]++;
                }
                if (dict[x] > mx)
                {
                    mx = dict[x];
                    ret = x;
                }
            }
            return ret;
        }
        static void Main()
        {
            ArrayList arrName = new ArrayList();
            arrName.Add("BOB");
            arrName.Add("JOHN");
            arrName.Add("TOM");
            arrName.Add("TOM");
            arrName.Add("TOM");
            string ans = GetMostPopular(arrName);
            Console.WriteLine(ans);
        }
