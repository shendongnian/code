    public abstract class ABaseType
    {
        public abstract void PrintSomethingToConsole();
    }
    public class ASubType : ABaseType
    {
        public override void PrintSomethingToConsole()
        {
            System.Console.WriteLine("Something");
        }
    }
    public class AnotherSubType : ABaseType
    {
        public override void PrintSomethingToConsole()
        {
            System.Console.WriteLine("Something else");
        }
    }
