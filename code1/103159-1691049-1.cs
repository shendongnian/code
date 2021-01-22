    static void Main(string[] args)
            {
                B b = new B();
                b.D.ID = 1;
                ((MyDTO)b.D).Name = "4";
                MyBLMethod(b);
            }
