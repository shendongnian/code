    public class ArrayPropertyClass
    {
        private string[] _sampleArray;
        public string[] SampleArray
        {
            get { return _sampleArray; }
        }
        public string FirstItem
        {
            get { return _sampleArray[0]; }
        }
        public string SecondItem
        {
            get { return _sampleArray[1]; }
        }
        public string ThirdItem
        {
            get { return _sampleArray[2]; }
        }
        public ArrayPropertyClass(int arraySize)
        {
            _sampleArray = new string[arraySize];
        }
    }    
    static void Main(string[] args)
    {
        ArrayPropertyClass apc = new ArrayPropertyClass(5);
        for (int i = 0; i < 5; ++i)
        {
            apc.SampleArray[i] = (i+1).ToString();
        }
        for (int i = 0; i < 5; ++i)
        {
            Console.WriteLine(apc.SampleArray[i]);
        }
        Console.WriteLine(apc.FirstItem);
        Console.WriteLine(apc.SecondItem);
        Console.WriteLine(apc.ThirdItem);
        Console.ReadLine();
    }
