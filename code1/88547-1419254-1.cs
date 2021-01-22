    static void Main(string[] args)
    {
        var accessorSource = new AccessorTest(5);
        var accessor1 = new AccessorTest();
        var accessor2 = new AccessorTest();
        accessor1.Value = accessor2.Value = accessorSource.Value;
        Console.ReadLine();
    }
    public class AccessorTest
    {
        public AccessorTest(int value = default(int))
        {
            _Value = value;
        }
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
