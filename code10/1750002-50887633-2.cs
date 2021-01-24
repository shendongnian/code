    using System; 
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player p = new Player();
            p.DisplayPlayerStatus();
    
            Console.WriteLine();
    
            p["Status", "health"] = 200;
            p.DisplayPlayerStatus();
    
            Console.ReadLine();
        }
        // the fixed stuff goes here
    }
