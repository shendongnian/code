    public interface ITargetInterface
    {
        void DoSomething();
    }
    // . . .
    public class TargetImplementation : ITargetInterface
    {
        public void DoSomething()
        {
            Console.WriteLine("ITargetInterface.DoSomething()");
        }
    }
    // . . .
    public interface IMixinInterfaceA
    {
        void MethodA();
    }
    // . . .
    public class MixinImplementationA : IMixinInterfaceA
    {
        public void MethodA()
        {
            Console.WriteLine("IMixinInterfaceA.MethodA()");
        }
    }
    // . . .
    public interface IMixinInterfaceB
    {
        void MethodB(int parameter);
    }
    // . . .
    public class MixinImplementationB : IMixinInterfaceB
    {
        public void MethodB(int parameter)
        {
            Console.WriteLine("IMixinInterfaceB.MethodB({0})", parameter);
        }
    }
