    class Program
    {
        void Apple()
        {
            List<Banana> apple = new List<Banana> { new Banana(new Cucumber(5)), new Banana(new Dates() { Feijoa = 6 }) };
        }
    }
    
    class Banana
    {
        private readonly ICommon instance;
    
        public Banana(ICommon instance)
        {
            this.instance = instance;
        }
    }
    
    public interface ICommon
    {
        int Feijoa { get; set; }
    }
    
    class Cucumber : ICommon
    {
        public Cucumber(int feijoa)
        {
            this.Feijoa = feijoa;
        }
    
        public int Feijoa { get; set; }
    }
    
    class Dates : ICommon
    {
        public Dates()
        {
        }
    
        public int Feijoa { get; set; }
    }
