    [Serializable]
    public class TestClass
    {
        int x = 2;
        int y = 4;
        public TestClass(){}
        public TestClass(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int TestFunction()
        {
            return x + y;
        }
    }
