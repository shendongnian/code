    import System;
    public abstract class AbstractBase<T>
        where T : AbstractBase<T>, new()
    {
        private static T _instance = new T();
        public abstract string Description { get; }
        public static string GetDescription()
        {
            return _instance.Description;
        }
    }
    public class DerivedClass : AbstractBase<DerivedClass>
    {
        public override string Description => "This is the derived Class";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DerivedClass.GetDescription());
            Console.ReadKey();
        }
    }
