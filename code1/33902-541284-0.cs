    using System;
    
    class DelphiRandom
    {
        int _seed;
        
        public DelphiRandom(int seed)
        {
            _seed = seed;
        }
        
        int GetNext() // note: returns negative numbers too
        {
            _seed = _seed * 0x08088405 + 1;
            return _seed;
        }
        
        public int Next(int maxValue)
        {
            long result = (uint) GetNext() * maxValue;
            return (int) (result >> 32);
        }
    }
    
    class App
    {
        static void Main()
        {
            DelphiRandom r = new DelphiRandom(42);
            for (int i = 0; i < 10; ++i)
                Console.WriteLine(r.Next(100));
        }
    }
