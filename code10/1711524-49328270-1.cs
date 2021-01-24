    public abstract class Class<T>
    {
        private readonly int number;
        internal int Number
        {
            get { return number; }
        }
        public Class()
            : this(5)
        {
        }
        public Class(int number)
        {
            this.number = number;
        }
        public void Print()
        {
            Console.WriteLine(number);
        }
    }
    public class ClassA : Class<ClassA>
    {
    }
    public class ClassB : Class<ClassB>
    {
        public ClassB()
            : base(1)
        {
        }
    }
    public class ClassC : Class<ClassC>
    {
        public ClassC(ClassA classA)
            : base(classA.Number)
        {
        }
    }
