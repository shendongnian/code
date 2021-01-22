    class Program
    {
        static void Main()
        {
            Child.Create(() => new Child(5));
            Console.ReadKey();
        }
    }
    public abstract class Parent
    {
        protected virtual void Initialize()
        {
            Console.Write(" is the number.");
        }
        public static TChild Create<TChild>(Func<TChild> childGetter)
            where TChild : Parent
        {
            var child = childGetter();
            child.Initialize();
            return child;
        }
    }
    public class Child : Parent
    {
        private int _number;
        public Child(int number)
        {
            _number = number;
        }
        protected override void Initialize()
        {
            Console.Write(_number.ToString());
            base.Initialize();
        }
    }
