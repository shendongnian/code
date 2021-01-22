    public class MyClass
    {
        public readonly IntIndexing IntProperty;
    
        public MyClass()
        {
            IntProperty = new IntIndexing(this);
        }
    
        private int GetInt(int index)
        {
            switch (index)
            {
                case 1:
                    return 56;
                case 2:
                    return 47;
                case 3:
                    return 88;
                case 4:
                    return 12;
                case 5:
                    return 32;
                default:
                    return -1;
            }
        }
    
        public class IntIndexing
        {
            private MyClass MC;
    
            internal IntIndexing(MyClass mc)
            {
                MC = mc;
            }
    
            public int this[int index]
            {
                get { return MC.GetInt(index); }
            }
        }
    }
