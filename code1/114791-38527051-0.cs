    public delegate void DelReturnValue(string value);
    public class SayHello
    {
        private string _name;
        private DelReturnValue _delReturnValue;
        public SayHello(string name, DelReturnValue delReturnValue)
        {
            _name = name;
            _delReturnValue = delReturnValue;
        }
        public void SayHelloMethod()
        {
            _delReturnValue(_name);
        }
    }
    public class Caller
    {
        private static string _returnedValue;
        public static void ReturnValue(string value)
        {
            _returnedValue = value;
        }
        public static void Main()
        {
            DelReturnValue delReturnValue=new DelReturnValue(ReturnValue);
            SayHello sayHello = new SayHello("test", delReturnValue);
            Thread newThread = new Thread(new ThreadStart(sayHello.SayHelloMethod));
            newThread.Start();
            Thread.Sleep(1000);
            Console.WriteLine("value is returned: " + _returnedValue);
        }
    }
