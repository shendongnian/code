    public class UnitManager
    {
        public string Name { get; set; }
        public string Firstname { get; set; }
        public UnitManager(string name, string firstname)
        {
            this.Name = name;
            this.Firstname = firstname;
        }
    }
    class Other
    {
        public static void AddTitle(UnitManager myUnit)
        {
            var titlePlusFullName = ("The Legendary" + " " + myUnit.Name + " " + myUnit.Firstname);
            myUnit.Name = titlePlusFullName;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var player1 = new UnitManager("john", "smith");
            var player2 = new UnitManager("jen", "doe");
            Other oT = new Other();
            Other.AddTitle(player1);
            Console.WriteLine("Player 1 name: " + player1.Name);
        }
    }
