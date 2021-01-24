    public abstract class Parent
    {
        public abstract string Name {get;}
    }
    
    public abstract class Child : Parent
    {
        
    }
    
    public class Grandchild: Child
    {
        public override string Name { get { return "Test"; } }
    }
