    namespace MySolution.Entity
    {
        public interface IMyInterface
        {        
            int Save(MyClass obj);
        }
    }
    
    namespace MySolution.Entity
    {
        public class MyClass
        {
            IMyInterface _myDa;
    
            public MyClass(IMyInterface myDa)
            {
                _myDa = myDa;
            }
    
            private string _message;
            public string Message
            {
                get { return _message; }
                set { _message = value; }
            }
    
            public int Save()
            {
                return _myDa.Save(this);
            }
        }
    }
    
    using MySolution.Entity;
    namespace MySolution.Service
    {
        public class MyClassService : IMyInterface
        {
            public int Save(MyClass obj)
            {
                Console.WriteLine(obj.Message);
    
                return 1;
            }
        }
    }
    
    using MySolution.Entity;
    using MySolution.Service;
    namespace MySolution.UI
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass myobj = new MyClass(new MyClassService());
                myobj.Message = "Goodbye Circular Dependency!";
                myobj.Save();
    
                Console.ReadLine();
            }
        }
    }
