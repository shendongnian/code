    class Monkey
    {
        public string Shock { get { return "Monkey has been shocked."; } }
    }
    static class MonkeyExtensionToSupportIWombat
    {
        public static string ShockTheMonkey(this Monkey m)
        {
            return m.Shock;
        }
    }
    interface IWombat
    {
        string ShockTheMonkey();
    }
    class MonkeyBat : Monkey, IWombat
    {
        #region IWombat Members
        public string ShockTheMonkey()
        {
            return this.Shock;
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            var monkey = new Monkey();
            Console.WriteLine("Shock the monkey without the interface: {0}", monkey.Shock);
            var monkeyBat = new MonkeyBat();
            Console.WriteLine("Shock the monkey with the interface: {0}", monkeyBat.ShockTheMonkey());
            Console.ReadLine();
        }
    }
