    public enum Status
    {
        Good,
        Bad,
        Indifferent
    };
    
    public class Program
    {
        static void Main(string[] args)
        {
            Status s = (Status) 30;
        }
    }
