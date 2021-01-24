    class Program
    {
        static void Main(string[] args)
        {
            ActOnIt(new DoSomething());
            Console.ReadKey();
        }
    
        public static void ActOnIt(object Obj)
        {
            Main received = (Main)Obj;
            received.DoCall("Print");
        }
    }
    
    public class DoSomething:Main
    {
        public void Print()
        {
            Console.WriteLine("HELLO WORLD");
        }
    }
    
    public abstract class Main
    {
        public void DoCall(string methodName)
        {
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(methodName);
            theMethod.Invoke(this, null);
        }
    }
