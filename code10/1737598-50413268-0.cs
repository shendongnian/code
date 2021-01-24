    class C : InputBase {
        public decimal AFee { get; set; }
        public decimal BFee { get; set; }
        public C(A a, B b) {
            if (a.DateCreated == b.DateCreated && a.Option1 == b.Option1 && a.Rate == b.Rate) {
                Option1 = a.Option1;
                Rate = a.Rate;
                DateCreated = a.DateCreated;
            } else {
                throw new ArgumentException("...");
            }
        }
        public C() {}
        public A GetA() {
            return new A { DateCreated = DateCreated, Option1 = Option1, Rate = Rate, Fee = AFee };
        }
        public B GetB() {
            return new B { DateCreated = DateCreated, Option1 = Option1, Rate = Rate, Fee = BFee };
        }
    }
