    public struct CountEnum
    {
        public readonly int Count;
    
        public static readonly CountEnum Four = new CountEnum(4);
        public static readonly CountEnum Six = new CountEnum(6);
        public static readonly CountEnum Eight = new CountEnum(8);
    
        private CountEnum(int count)
        {
            Count = count;
        }
    }
    
    public class Class1
    {
        public Class1(CountEnum countEnum)
        { 
            // Access the value via countEnum.Count.
        }
    }
