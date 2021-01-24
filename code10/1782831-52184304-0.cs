    public interface ISaveAble{ }
    class Animal : ISaveAble
    {
        public int Legs { get; set; }
    }
    
    class Dog : Animal 
    {
    	public int TailLength { get; set; }
    }
