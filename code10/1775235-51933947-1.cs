    public class CountVisitor : IVisitor<int, Foo> , IVisitor<string, Bar>
    {
        public int Visit(Foo visitable) => 42;
        public string Visit(Bar visitable) => "42";
    }
