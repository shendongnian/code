    using System.Runtime.Serialization;
    namespace ConsoleApp4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var employeeWorker = new GenericWorker<Employee>();
                employeeWorker.DoWork();
            }
        }
        public class GenericWorker<T> where T:IConstructor
        {
            public void DoWork()
            {
                T employee = (T)FormatterServices.GetUninitializedObject(typeof(T));
                employee.Constructor("John Doe", 105);
            }
        }
        public interface IConstructor
        {
            void Constructor(string name, int age);
        }
        public class Employee : IConstructor
        {
            public string Name { get; private set; }
            public int Age { get; private set; }
            public Employee(string name, int age)
            {
                ((IConstructor)this).Constructor(name, age);
            }
            void IConstructor.Constructor(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }
    }
