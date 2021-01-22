    public static class TestExt
    {
        public static int Min(this Test test)
        {
            return Math.Min(test.val, test.Tests.Min(x => x.Min()));
        }
    }
    public class Test
    {
        public int val;
        public List<Test> Tests;
    }
    public class LinqTest
    {
        public void GetMin()
        {
            Test t = new Test();
            var min = t.Min();
        }
    }
