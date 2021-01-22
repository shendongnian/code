    struct lala
    {
        private readonly bool state1; // note: readonly
        public lala(bool state1)
        {
            this.state1 = state1;
        }
        public lala SetState1ToTrue()
        {
            return new lala(true); // would copy any other fields, unchanged
        }
        public bool GetState1()
        {
            return this.state1;
        }
    }
