    public class Person
    {
        public string Name;
    
        public virtual void Accept(IPersonVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    
