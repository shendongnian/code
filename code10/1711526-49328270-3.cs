    public abstract class Class<T>
    {
        private static int number = 5;
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
        private static int number;
        public ClassB()
        {
            number = 1;
        }
    }
    public class ClassC : Class<ClassC>
    {
        private static int number;
        public ClassC()
        {
            number = 123; // Cannot see ClassA.number because it is private to `Class<T>`
        }
    }
