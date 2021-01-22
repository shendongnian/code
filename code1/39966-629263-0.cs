    class Foo{
        public Int32 Value { get; set; }
        public Byte ToByte() { return Convert.ToByte(Value); }
        public Double ToDouble() { return (Double)Value; }
        public new String ToString() { return Value.ToString("#,###"); }
    }
