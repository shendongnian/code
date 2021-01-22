    /* Results
    Class1
    Base1
    Class2
    Class2
    */
    public abstract class Base1
    {
        public void DoIt() { Console.WriteLine("Base1"); }
    }
    public  class Class1 : Base1 
    {
        public new void DoIt() { Console.WriteLine("Class1"); }
    }
    public abstract class Base2
    {
        public virtual void DoIt() { Console.WriteLine("Base2"); }
    }
    public class Class2 : Base2
    {
        public override void DoIt() { Console.WriteLine("Class2"); }
    }
    static void Main(string[] args)
    {
        var c1 = new Class1();
        c1.DoIt();
        ((Base1)c1).DoIt();
    
        var c2 = new Class2();
        c2.DoIt();
        ((Base2)c2).DoIt();
        Console.Read();
    }
