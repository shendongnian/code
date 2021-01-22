    class Program
    {
        static void Main(string[] args)
        {
            foreach (String foo in new Foo())
            {
                Console.WriteLine(foo);
            }
        }
    }
    class Foo : IEnumerable<String>
    {
        #region IEnumerable<string> Members
        public IEnumerator<string> GetEnumerator()
        {
            yield return "fake # 1";
            yield return "fake # 2";
        }
        #endregion
        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
