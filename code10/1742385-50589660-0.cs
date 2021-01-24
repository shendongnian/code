    public class Cow
    {
        public int Age { get; set; }
        public int Weight { get; set; }
    }
    
    static void Main(string[] args)
    {
        string csv = @"Weight,Age
        300,10
        319,11
        100,1
        370,9";
    
        foreach (Cow rec in ChoCSVReader<Cow>.LoadText(csv).WithFirstLineHeader())
        {
            Console.WriteLine($"Age: {rec.Age}, Weight: {rec.Weight}");
        }
    }
