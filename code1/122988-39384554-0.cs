    public abstract class Person
    {
        public string Name { get; protected set; }
        public abstract void GiveName(string inName);
    }
    public class Employee : Person
    {
        public override void GiveName(string inName)
        {
            Name = inName;
        }
    }
    public class SalesPerson:Employee
    {
        public override void GiveName(string inName)
        {
            Name = "Sales: "+inName;
        }
    }
