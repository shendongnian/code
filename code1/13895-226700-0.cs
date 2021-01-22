        public IOrderedQueryable<int> GetOrderedQueryable()
        {
            IQueryable<int> myInts = new List<int>() { 3, 4, 1, 2 }.AsQueryable<int>();
            return myInts.Where(i => i == 2);
        }
