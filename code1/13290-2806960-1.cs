        [TestMethod()]
        public void LINQ_StringBuilder()
        {
            IList<int> ints = new List<int>();
            for (int i = 0; i < 3000;i++ )
            {
                ints.Add(i);
            }
            StringBuilder idString = new StringBuilder();
            foreach (int id in ints)
            {
                idString.Append(id + ", ");
            }
        }
        [TestMethod()]
        public void LINQ_SELECT()
        {
            IList<int> ints = new List<int>();
            for (int i = 0; i < 3000; i++)
            {
                ints.Add(i);
            }
            string ids = ints.Select(query => query.ToString())
                             .Aggregate((a, b) => a + ", " + b);
        }
