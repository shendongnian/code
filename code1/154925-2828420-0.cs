    // CALLER
    public class Program
    {
        static void Main(string[] args)
        {
            Device<Command1, S1> cmd1 = new Device<Command1, S1>();
            S1 s1 = cmd1.ExecuteCommand(new Command1());
    
            Device<Command2, S2> cmd2 = new Device<Command2, S2>();
            S2 s2 = cmd2.ExecuteCommand(new Command2());
        }
    }
    // SDK
    public interface ICommand<T>
    {
        T Execute();
    }
    
    public struct S1
    {
        public int id;
    }
    
    public struct S2
    {
        public string name;
    }
    
    public class Command1 : ICommand<S1>
    {
        public S1 Execute()
        { return new S1() { id = 1 }; }
    }
    
    public class Command2 : ICommand<S2>
    {
        public S2 Execute()
        { return new S2() { name = "name" }; }
    }
    
    // DEVICE
    public class Device<T, U> where T : ICommand<U>
    {
        public U ExecuteCommand(T cmdObject)
        {
            return cmdObject.Execute();
        }
    } 
