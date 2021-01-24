    public class Person
    {
        [Obsolete("Obsolete field")]
        public int Field { get; set; }
        [Obsolete("Obsolete property")]
        public int Property { get; set; }
        [Obsolete("Obsolete method")]
        public void blahblahblah()
        { }
    }
