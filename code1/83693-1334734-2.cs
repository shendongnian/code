    public class Derived
    {
        readonly Base b;
        public Derived(Base b) {this.b=b;}
        public List<Base> Children;
        public string Member1 {get {return b.Member1;} set {...} }
        public int Member2 {etc}
        public float Member3 {etc}
        public bool Member4 {etc}
    }
