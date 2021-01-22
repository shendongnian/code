    using System;
    
    public struct LooksImmutable
    {
        private readonly int value;
        public int Value { get { return value; } }
        
        public LooksImmutable(int value)
        {
            this.value = value;
        }
        
        public void GoCrazy()
        {
            this = new LooksImmutable(value + 1);
        }
    }
    
    public class Test
    {
        static void Main()
        {
            LooksImmutable x = new LooksImmutable(5);
            Console.WriteLine(x.Value);
            x.GoCrazy();
            Console.WriteLine(x.Value);
        }
    }
