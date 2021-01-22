    public abstract class T {
        public abstract X Match<X>(Func<A,X> aCase, Func<B,X> bCase, Func<C,X> cCase);
        private class ACase : T {
            private A a;
            public ACase(A a) { this.a = a; }
            public override X Match<X>(Func<A,X> aCase, Func<B,X> bCase, Func<C,X> cCase) {
                return aCase(a);
            }
        }
        private class BCase : T {
            private B b;
            public BCase(B b) { this.b = b; }
            public override X Match<X>(Func<A,X> aCase, Func<B,X> bCase, Func<C,X> cCase) {
                return bCase(b);
            }
        }
        private class CCase : T {
            private C c;
            public CCase(C c) { this.c = c; }
            public override X Match<X>(Func<A,X> aCase, Func<B,X> bCase, Func<C,X> cCase) {
                return cCase(c);
            }
        }
        public static T MakeACase(A a) { return new ACase(a); }
        public static T MakeBCase(B b) { return new BCase(b); }
        public static T MakeCCase(C c) { return new CCase(c); }
    }
