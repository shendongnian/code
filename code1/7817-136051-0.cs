    public class Foo
    {
        private int[] _someInts = { 1, 2, 3, 4, 5, 6 };
        public IEnumerator GetEnumerator()
        {
            foreach (var item in _someInts)
            {
                yield return item;
            }
        }
    }
