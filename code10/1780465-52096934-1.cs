    public class Foo { }
    public class Bar { }
    public interface IData<T>
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
    public abstract class Operation<TD1, TD2, T1, T2>
        where TD1 : IData<T1>
        where TD2 : IData<T2>
    {
        public abstract TD2 Run(TD1 input);
    }
    public class FbOperation : Operation<Foos, Bars, Foo, Bar>
    {
        public override Bars Run(Foos input)
        {
            // TODO
            return new Bars();
        }
    }
