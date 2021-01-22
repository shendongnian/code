        public new void Print(C c)
        {
            Console.WriteLine("B:C(" + c.A() + "," + c.B() + ")");
        }
        public void Print(I i)
        {
            Console.WriteLine("B:I(" + i.A() + ")");
        }
