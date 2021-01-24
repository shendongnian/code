        public interface IOne{void MyMethod();}
        public interface ITwo{void MyMethod();}
        public class MyClass: IOne, ITwo
        {
            public void MyMethod()
            {
                Console.WriteLine("Hello!");
            }
        }
        public static void Main()
        {
            new MyClass().MyMethod();
        }
