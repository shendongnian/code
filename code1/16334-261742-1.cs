    public class Base
    {
        protected internal void FigureItOut<TClass, TMember>(Expression<Func<TClass, TMember>> expr)
        {
            Debug.WriteLine("Got to actual method");
        }
    }
    
    public static class BaseExt
    {
        public static void FigureItOut<TClass, TMember>(this TClass source, Expression<Func<TClass, TMember>> expr)
            where TClass : Base
        { // call the actual method
            Debug.WriteLine("Got to extension method");
            source.FigureItOut(expr);
        }
    }
    public class Descendant : Base
    {
        public void TestMethod()
        {
            this.FigureItOut(c => c.Name);
        }
    
        public String Name { get; set; }
    }
