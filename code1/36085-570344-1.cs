        public static void Test1()
        {
            List<int> myList = new List<int>() {2,1,42,0,9,6,5,3,8};
            foreach (var g in myList.GetSequences(i => i < 6))
            {
                Console.WriteLine("g");
                foreach (int i in g)
                {
                    Console.WriteLine(i);
                }
            }
        }
