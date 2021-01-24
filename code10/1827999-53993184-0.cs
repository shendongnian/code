    public class Upgrades
    {
        public Upgrades()
        {
            var program = new Program();
            program.Variable = 20; //its ok.
        }
    }
    
    public class Program
    {
        public int Variable { get; set; }
    }
