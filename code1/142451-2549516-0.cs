    public class ParentClass
    {
        private x;
        private y;
        private z;
        something.something = new ChildClass(this);
        public class ChildClass
        {
            private ParentClass pc;
            public ChildClass(ParentClass pc){
                this.pc = pc;
            }
            // need to get x, y and z;
            public void GetValues() {
                myX = pc.X
                ...
            }
        }
    }
