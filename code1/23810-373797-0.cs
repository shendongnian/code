    public interface IFooFormat
    {
    }
    public class FooFormat<TValue> : IFooFormat
    {
        private TValue _value;
        public void Init(TValue value)
        {
            _value = value;
        }
        public TValue Value
        {
            get { return _value; }
        }
    }
    public class ArrayFooFormat : FooFormat<IList<string>> { }
    public class BooleanFooFormat : FooFormat<bool> { }
    public class DefaultFooFormat : IFooFormat { }
    public interface IFoo { }
    public class Foo : IFoo
    {
        private IFooFormat _format;
        internal Foo(IFooFormat format)
        {
            _format = format;
        }
        public IFooFormat Format { get { return _format; } }
    }
    public class FooFactory
    {
        protected IFoo Build<TFormat, TArg>(TArg arg) where TFormat : FooFormat<TArg>, new()
        {
            TFormat format = new TFormat();
            format.Init(arg);
            return new Foo(format);
        }
        protected IFoo Build<TFormat>() where TFormat : IFooFormat, new()
        {
            return new Foo(new TFormat());
        }
    }
