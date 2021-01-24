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
    public class Other
    {
         public void doSomething(UnitManager myUnit) {
                 //do something with each unit manager
         }
    }
    public class Program
    {
        static void Main(string[] args)
    {
        var player1 = new UnitManager("p1Name", "p1FirstName");
        var player2 = new UnitManager("p2Name", "p2FirstName");
        Other ot = new Other();
        result1 = ot.doSomething(player1);
        result2 = ot.doSomething(player2);
    }
    }
