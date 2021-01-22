    class MyList : IEnumerable<int>
    {
        int maxCount = 0;
        public int RequestCount
        {
            get;
            private set;
        }
        public MyList(int maxCount)
        {
            this.maxCount = maxCount;
        }
        public void Reset()
        {
            RequestCount = 0;
        }
        #region IEnumerable<int> Members
        public IEnumerator<int> GetEnumerator()
        {
            int i = 0;
            while (i < maxCount)
            {
                RequestCount++;
                yield return i++;
            }
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList(15);
            list.Take(5).ToArray();
            Console.WriteLine(list.RequestCount); // 5;
            list.Reset();
            list.OrderBy(q => q).Take(5).ToArray();
            Console.WriteLine(list.RequestCount); // 15;
            list.Reset();
            list.Where(q => (q & 1) == 0).Take(5).ToArray();
            Console.WriteLine(list.RequestCount); // 9; (first 5 odd)
            
            list.Reset();
            list.Where(q => (q & 1) == 0).Take(5).OrderBy(q => q).ToArray();
            Console.WriteLine(list.RequestCount); // 9; (first 5 odd)
        }
    }
