    class EmptyClass : IDoSomething, IDoSomethingElse
    {
    }
    interface IDoSomething
    {
    }
    interface IDoSomethingElse
    {
    }
    static class InterfaceExtensions
    {
        public static int DoSomething(this IDoSomething tThis)
        {
            return 8;
        }
        public static int DoSomethingElse(this IDoSomethingElse tThis)
        {
            return 4;
        }
    }
