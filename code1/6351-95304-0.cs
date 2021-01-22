    public class Program
    {
        static System.Threading.Mutiex singleton = new Mutext(true, "My App Name");
    
        static void Main(string[] args)
        {
            if (!singleton.WaitOne(TimeSpan.Zero, true))
            {
                //there is already another instance running!
                System.Exit(1);
            }
        }
    }
