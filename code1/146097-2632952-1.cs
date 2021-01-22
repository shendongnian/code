    abstract class Ia
    {
        public abstract void Serialize();
    }
    class A : Ia
    {
        public int a = -1;
        sealed public override void Serialize() {
            Console.Out.WriteLine("In A serialize");
        }
    };
    class B : A
    {
        public int b = 0;
        /*
         * Error here -
        public override void Serialize()
        {
            Console.Out.WriteLine("In B serialize");
        }
         */
        //this is ok. This can only be invoked by B's objects.
        public new void Serialize()
        {
            Console.Out.WriteLine("In B serialize");
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            A aobj = new B();
            aobj.Serialize();
            Console.In.ReadLine();
        }
    }
    //Output: In A serialize
