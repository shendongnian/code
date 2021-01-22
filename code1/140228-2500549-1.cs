    public class RelatedReference<A, B>
    {
        private A a;
        private B b;
        public B Referent
        {
            get {return b;}
        }
        public RelatedReference(A a, B b)
        {
            this.a = a; 
            this.b = b;
        }
    }
