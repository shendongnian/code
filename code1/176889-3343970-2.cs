        static void Main(string[] args)
        {
            string s1 = "i have a car a car";
            string s2 = "i have a new car bmw";
            List<string> diff;
            IEnumerable<string> set1 = s1.Split(' ').Distinct();
            IEnumerable<string> set2 = s2.Split(' ').Distinct();
            if (set2.Count() > set1.Count())
            {
                diff = set2.Except(set1).ToList();
            }
            else
            {
                diff = set1.Except(set2).ToList();
            }
        }
