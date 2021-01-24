    public class Foo { }
    public class Bar { }
    public interface IData { }
    public interface IData<T> : IData
    {
        List<T> List{ get; set; }
    }
    public class Foos : IData<Foo>
    {
        public List<Foo> List{ get; set; }
    }
    public class Bars : IData<Bar>
    {
        public List<Bar> List{ get; set; }
    }
    public abstract class Operation<TD1, TD2>
        where TD1 : IData
        where TD2 : IData
    {
        public abstract TD2 Run(TD1 input);
    }
    public class FbOperation : Operation<Foos, Bars>
    {
        public override Bars Run(Foos input)
        {
            // TODO
            return new Bars();
        }
    }
