    class B
    {
        public B(int data) 
        { 
            this.data = data; 
        }
    
        public int data
        {
            get { return privateData; }
            set { privateData = value; }
        }
    
        private int privateData;
    }
    
    class ProxyB
    {
        public ProxyB(B b)   
        { 
            actual = b; 
        }
    
        public int data
        {
            get { return actual.data; }
        }
    
        private B actual;
    }
    
    class A : IEnumerable<ProxyB>
    {
        private List<B> bList = new List<B>();
    
        class ProxyEnumerator : IEnumerator<ProxyB>
        {
            private IEnumerator<B> b_enum;
    
            public ProxyEnumerator(IEnumerator<B> benum)
            {
                b_enum = benum;
            }
    
            public bool MoveNext()
            {
                return b_enum.MoveNext();
            }
    
            public ProxyB Current
            {
                get { return new ProxyB(b_enum.Current); }
            }
    
            Object IEnumerator.Current
            {
                get { return this.Current; }
            }
    
            public void Reset()
            {
                b_enum.Reset();
            }
    
            public void Dispose()
            {
                b_enum.Dispose();
            }
        }
    
        public void AddB(B b) { bList.Add(b); }
    
        public IEnumerator<ProxyB> GetEnumerator()
        {
            return new ProxyEnumerator(bList.GetEnumerator());
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
