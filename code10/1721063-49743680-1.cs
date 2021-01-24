    public class Parent { }
    public class Child:Parent { public string ChildProperty; }
    public abstract class ParentClass
    {
        public abstract Parent ItemValue { get; }
    }
    public class ChildClass : ParentClass
    {
        Child item;
        public override Parent ItemValue { get {return item;} }
	
        public void Method()
        {
           // use item's child class properties
           Console.Write(item.ChildProperty);
        }
    }
