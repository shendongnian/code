    public interface IVisitable<R, out T> where T: IVisitable<int, T>
    {
        R Accept(IVisitor<R, T> visitor);
    }
    
    public class Foo : IVisitable<int, Foo>
    {
        public int Accept(IVisitor<int, Foo> visitor) => visitor.Visit(this);
    }
    
    public class Bar : IVisitable<int, Bar>
    {
        public int Accept(IVisitor<int, Bar> visitor) => visitor.Visit(this);
    }
    
    public interface IVisitor<out TResult, in T> where T: IVisitable<int, T>
    {
        TResult Visit(T visitable);
    }
    
    public class CountVisitor : IVisitor<int, Foo>, IVisitor<int, Bar>
    {
        public int Visit(Foo visitable) => 42;
        public int Visit(Bar visitable) => 7;
    }
    
    class Program {
    	static void Main(string[] args) {
    		var theFoo = new Foo();
    		int count = theFoo.Accept(new CountVisitor());
    	}
    }
