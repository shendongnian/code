    class MyPredicate {
        public string ID;
        public bool Predicate(Subject s) {
            return s.ID == this.ID;
        }
    }
