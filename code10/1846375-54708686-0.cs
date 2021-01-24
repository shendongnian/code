    public class ArrayPropertyClass
    {
        private int[] _sampleArray;
    
        public int[] SampleArray
        {
            get { return _sampleArray; }
        }
    
        public ArrayPropertyClass(int arraySize)
        {
            _sampleArray = new int[arraySize];
        }
    }
    
    static void Main(string[] args)
    {
        ArrayPropertyClass apc = new ArrayPropertyClass(5);
        for (int i = 0; i < 5; ++i)
        {
            apc.SampleArray[i] = i+1;
        }
        for (int i = 0; i < 5; ++i)
        {
            Console.WriteLine(apc.SampleArray[i]);
        }
        Console.ReadLine();
     }
