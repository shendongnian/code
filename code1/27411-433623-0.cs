    class BaseClass
    {
        public int x;
        
        public BaseClass(int StartX)
        {
            this.x = StartX;
        }
    }
    class ChildClass: BaseClass
    {
        public int Y;
        
        public BaseClass(int StartX, StartY): base(StartX)
        {
            this.y = StartY;
        }
    }
    class Program
    {
        public static void Main()
        {
            BaseClass B = new BaseClass(3);
            ChildClass C = (ChildClass)B;
            Console.WriteLine(C.y);
        }
    }
