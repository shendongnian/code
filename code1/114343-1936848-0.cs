    public class Foo
    {
        public string Blah { get; set; }
        public int Bar_A { get; set; }
        public int Bar_B { get; set; }
    
        /* not mapped to DB */
        public Bar Yada
        {
            get { return new Bar { A = this.Bar_A, B = this.Bar_B }; }
            set { this.Bar_A = value.A; this.Bar_B = value.B; }
        }
    }
    
    public struct Bar
    {
        public int A { get; set; }
        public int B { get; set; }
    }
