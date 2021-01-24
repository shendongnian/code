        public static void Main(string[] args)
        {
            int N = 7;
            Console.WriteLine("Sequence: " + string.Join(", ", genSequence(new List<int>(), N).ConvertAll<string>(i => i.ToString()).ToArray()));
        }
        
        private static List<int> genSequence(List<int> lst, int n)
        {
            lst.Add(n);
            if (n > 1)
            {
                genSequence(lst, n - 2);
                lst.Add(n);
            }
            return lst;
        }
