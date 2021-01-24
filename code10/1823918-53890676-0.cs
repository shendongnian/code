    public class A
    {
        [TypeConverter(typeof(BConverter))]
        public B B { get; set; }
    }
    public class B : ICloneable
    {
        [RefreshProperties(RefreshProperties.All)]
        public string C { get; set; }
        public object Clone()
        {
            return new B { C = this.C };
        }
        public override string ToString()
        {
            return C;
        }
    }
