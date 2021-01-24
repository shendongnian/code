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
        //create an object of type UnitManager and place it into variable player1
        var player1 = new UnitManager("p1Name", "p1FirstName");
        //create an object of type UnitManager and place it into variable player2
        var player2 = new UnitManager("p2Name", "p2FirstName");
        //create an instance of the class Other
        Other ot = new Other();
         
        //call the method within the instantiated class ot (of type Other) and
        //pass it the instance of the object UnitManager with a name
        //of player1
        result1 = ot.doSomething(player1);
        result2 = ot.doSomething(player2);
    }
    }
