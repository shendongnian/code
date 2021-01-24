    public class Fun
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
        public void Apply(byte[] ar)
        {
            A = ar[0];
            B = ar[1];
            C = ar[2];
        }
        public byte[] GetAll()
        {
            byte[] ar = new byte[3];
            ar[0] = A;
            ar[1] = B;
            ar[2] = C;
        }
    }
    public class NotFun
    {
        Fun fun1 = new Fun();
        Fun fun2 = new Fun();
        
        void Something()
        {
            fun1.Apply(new byte[3] { 1, 2, 3 });
            int a = fun1.A;
        }
    }
