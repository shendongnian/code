    class Program
    {
        static void Main(string[] args)
        {
            //ACTUAL usage
            //Setting up the interface injection
            IInjectableFactory.StaticInjectable = new ConcreteInjectable(1);
            //Injecting via the constructor
            EverythingsInjected injected = 
                new EverythingsInjected(new ConcreteInjectable(100));
            //Injecting via the property
            injected.PropertyInjected = new ConcreteInjectable(1000);
            //using the injected items
            injected.PrintInjectables();
            Console.WriteLine();
            //FOR TESTING (normally done in a unit testing framework)
            IInjectableFactory.StaticInjectable = new TestInjectable();
            EverythingsInjected testInjected = 
                new EverythingsInjected(new TestInjectable());
            testInjected.PropertyInjected = new TestInjectable();
            //this would be an assert of some kind
            testInjected.PrintInjectables(); 
            Console.Read();
        }
        //the inteface you want to represent the decoupled class
        public interface IInjectable { void DoSomething(string myStr); }
        
        //the "real" injectable
        public class ConcreteInjectable : IInjectable
        {
            private int _myId;
            public ConcreteInjectable(int myId) { _myId = myId; }
            public void DoSomething(string myStr)
            {
                Console.WriteLine("Id:{0} Data:{1}", _myId, myStr);
            }
        }
        //the place to get the IInjectable (not in consuming class)
        public static class IInjectableFactory
        {
            public static IInjectable StaticInjectable { get; set; }
        }
        //the consuming class - with three types of injection used
        public class EverythingsInjected
        {
            private IInjectable _interfaceInjected;
            private IInjectable _constructorInjected;
            private IInjectable _propertyInjected;
            //property allows the setting of a different injectable
            public IInjectable PropertyInjected
            {
                get { return _propertyInjected; }
                set { _propertyInjected = value; }
            }
            //constructor requires the loosely coupled injectable
            public EverythingsInjected(IInjectable constructorInjected)
            {
                //have to set the default with property injected
                _propertyInjected = GetIInjectable();
                
                //retain the constructor injected injectable
                _constructorInjected = constructorInjected;
                //using basic interface injection
                _interfaceInjected = GetIInjectable();
            }
            //retrieves the loosely coupled injectable
            private IInjectable GetIInjectable()
            {
                return IInjectableFactory.StaticInjectable;
            }
            //method that consumes the injectables
            public void PrintInjectables()
            {
                _interfaceInjected.DoSomething("Interface Injected");
                _constructorInjected.DoSomething("Constructor Injected");
                _propertyInjected.DoSomething("PropertyInjected");
            }
        }
        //the "fake" injectable
        public class TestInjectable : IInjectable
        {
            public void DoSomething(string myStr)
            {
                Console.WriteLine("Id:{0} Data:{1}", -10000, myStr + " For TEST");
            }
        }
