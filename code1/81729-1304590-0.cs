    public class Fluently
    {
        public FluentlyIs Is(string lhs)
        {
            return this;
        }
        public FluentlyDoes Does(string lhs)
        {
            return this;
        }
    }
    public class FluentlyIs
    {
        FluentlyIs LessThan(string rhs)
        {
            return this;
        }
        FluentlyIs GreaterThan(string rhs)
        {
            return this;
        }
    }
    public class FluentlyDoes
    {
        FluentlyDoes EqualTo(string rhs)
        {
            return this;
        }
    }
