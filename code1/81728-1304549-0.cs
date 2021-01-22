    public class Fluently : IFluentlyDoes, IFluentlyIs
    {
        public IFluentlyIs Is(string lhs)
        {
            return this;
        }
        public IFluentlyDoes Does(string lhs)
        {
            return this;
        }
        Fluently IFluentlyDoes.EqualTo(string rhs)
        {
            return this;
        }
        Fluently IFluentlyIs.LessThan(string rhs)
        {
            return this;
        }
        Fluently IFluentlyIs.GreaterThan(string rhs)
        {
            return this;
        }
    }
    public interface IFluentlyIs
    {
        Fluently LessThan(string rhs);
        Fluently GreaterThan(string rhs);
    }
    public interface IFluentlyDoes
    {    // grammar not included - this is just for illustration!
        Fluently EqualTo(string rhs);
    }
