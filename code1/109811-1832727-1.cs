        public void myMethod() {
            foreach (var y in myMethod2()) {
            }
        }
        public IQueryable<???> myMethod2() {
            return from c in IEnumerable select new { Prop = value };
        }
