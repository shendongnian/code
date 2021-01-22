    public class Foo 
    { 
        public Int32 Seed { get; set; }
    }
    public interface ISpecification<T> 
    {
        bool IsSatisfiedBy(T item);
    }
    public interface IFooSpecification : ISpecification<Foo> 
    {
        T Accept<T>(IFooSpecificationVisitor<T> visitor);
    }
    
    public class SeedGreaterThanSpecification : IFooSpecification
    {
        public SeedGreaterThanSpecification(int threshold)
        {
            this.Threshold = threshold;
        }
        public Int32 Threshold { get; private set; }
        public bool IsSatisfiedBy(Foo item) 
        {
            return item.Seed > this.Threshold ;
        }
        public T Accept<T>(IFooSpecificationVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
    public interface IFooSpecificationVisitor<T>
    {
        T Visit(SeedGreaterThanSpecification acceptor);
        T Visit(SomeOtherKindOfSpecification acceptor);
        ...
    }
    public interface IFooRepository 
    {
        IEnumerable<Foo> Select(IFooSpecification specification);
    }
    public interface ISqlFooSpecificationVisitor : IFooSpecificationVisitor<String> { }
    public class SqlFooSpecificationVisitor : ISqlFooSpecificationVisitor
    {
        public string Visit(SeedGreaterThanSpecification acceptor)
        {
            return "Seed > " + acceptor.Threshold.ToString();
        }
        ...
    }
    public class FooRepository
    {   
        private ISqlFooSpecificationVisitor visitor;
        public FooRepository(ISqlFooSpecificationVisitor visitor)
        {
            this.visitor = visitor;
        }
        
        public IEnumerable<Foo> Select(IFooSpecification specification)
        {
            string sql = "SELECT * FROM Foo WHERE " + specification.Accept(this.visitor);
            return this.DoSelect(sql);
        }
        
        private IEnumerable<Foo> DoSelect(string sql)
        {
            //perform the actual selection;
        }
    }
