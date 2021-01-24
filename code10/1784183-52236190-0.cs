    namespace DelegateExamples
    {
        class Program
        {
            //Declare a integer delegate to handle the functions in class A and B
            public delegate int MathOps(int a, int b);
            static void Main(string[] args)
            {
                MathOps multiply = ClassA.Multiply;
                MathOps add = ClassB.Add;
                int resultA = multiply(30, 30);
                int resultB = add(1000, 500);
                Console.WriteLine("Results: " + resultA + " " + resultB);
                Console.ReadKey();
            }
        }
        public class ClassA
        {
            public static int Multiply(int a, int b)
            {
                return a * b;
            }
        }
        public class ClassB
        {
            public static int Add(int a, int b)
            {
                return a + b;
            }
        }
    }
