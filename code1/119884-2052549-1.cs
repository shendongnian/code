    public class A
    {
        private B bObj = new B();
        public A()
        {
            B copy = bObj.Clone() as B;
        }
    }
    [Serializable]
    public class B : ICloneable
    {
        private int test = 10;
        public object Clone()
        {
            return Helper.Clone(this);
        }
    }
