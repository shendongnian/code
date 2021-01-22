    // No compiling!
    public class A
    {
        public virtual string GetName()
        {
            return "A";
        }
    }
    public class B:A
    {
        public override string GetName()
        {
            return "B";
        }
    }
    public class C:B
    {
        public new string GetName()
        {
            return "C";
        }
    }
    void Main()
    {
        Console.Write ( "Type a or c: " );
        string input = Console.ReadLine();
        A instance = null;
        if      ( input == "a" )   instance = new A();
        else if ( input == "c" )   instance = new C();
       Console.WriteLine( instance.GetName() );
    }
    // No compiling!
