    public class Thingy
    {
        public virtual void StepA()
        {
            Console.Out.WriteLine("Zing");
        }
        public void Action()
        {
            StepA();
            Console.Out.WriteLine("A Thingy in Action.");
        }
    }
    public class Widget : Thingy
    {
        public override void StepA()
        {
            Console.Out.WriteLine("Wiggy");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Thingy thingy = new Thingy();
            Widget widget = new Widget();
            thingy.Action();
            widget.Action();
            Console.Out.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
     }
