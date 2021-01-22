    public class ParentClass
    {
        public X;
        public Y;
        public Z;
        // give the ChildClass instance a reference to this ParentClass instance
        ChildClass cc = new ChildClass(this);
        public class ChildClass
        {
            private ParentClass _pc;
            public ChildClass(ParentClass pc) {
                _pc = pc;
            }
            // need to get X, Y and Z;
            public void GetValues() {
                myX = _pc.X
                ...
            }
        }
    }
