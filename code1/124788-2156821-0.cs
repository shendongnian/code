    class MyBO
    {
        public byte x1 { get; set; }   
    }
    // ...
    public static void Main(string[] args)
    {
        MyBO my1 = new MyBO() {x1 = 20};
        MyBO my2 = new MyBO() {x1 = (byte)20};
        MyBO my3 = new MyBO() {x1 = Convert.ToByte(20)};
    }
