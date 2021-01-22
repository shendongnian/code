    public class Test
    {
        public int val;
        public List<Test> Tests;
        public int Min()
        {
            return Math.Min(val,Tests.Min(x => x.Min()));
        }
    }
