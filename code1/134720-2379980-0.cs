    public class Something {
        public long Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (((Something)obj) == null)
                return false;
            Something s = (Something)obj;
            return this.Id == s.Id && string.Equals(this.Name, s.Name);
        }
        public bool Equals(Something s) {
            if (s == null)
                return false;
            return this.Id == s.Id && string.Equals(this.Name, s.Name);
        }
    }
