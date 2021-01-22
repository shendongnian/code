    static void Main(string[] args)
    {
        var accessor1 = new AccessorTest();
        var accessor2 = new AccessorTest();
        accessor1.Value = accessor2.Value = 5;
        Console.ReadLine();
    }
    public class AccessorTest
    {
        private int _Value;
        public int Value
        {
            get
            {
                Console.WriteLine("AccessorTest.Value.get {0}", _Value);
                return _Value;
            }
            set
            {
                Console.WriteLine("AccessorTest.Value.set {0}", value);
                _Value = value;
            }
        }
    }
