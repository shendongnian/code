    struct S
    {
        private int x;
        public void M()
        {
            this.x = 123;
        }
    }
    ...
    S s = new S();
    s.M();
