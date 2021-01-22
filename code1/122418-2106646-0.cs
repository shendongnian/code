    class Subject {
        public string ID { get; set; }
    }
    class MyPredicate {
        public string ID;
        public bool Predicate(Subject o) {
            return o.ID == this.ID;
        }
    }
