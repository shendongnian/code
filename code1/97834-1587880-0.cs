    class Visitor 
    {
        internal virtual void Visit(Node n) { Console.WriteLine("In normal visitor"); }
    }
    
    class VisitorSpecial : Visitor 
    {
        internal override void Visit(Node n) { Console.WriteLine("In special visitor"); }
    }
    
    class Base
    { 
        internal virtual void Accept(Visitor v) { }
    }
    
    class Node : Base
    {
        internal override void Accept(Visitor v){ v.Visit(this); }
    }
