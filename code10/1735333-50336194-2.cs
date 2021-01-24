    public class Employee : Person
    {
        public int EmployeeID;
        public override void Accept(IPersonVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
