    public interface IFoo
    {
        object Value { get; set; }
    }
    
    public class Foo<T> : IFoo
    {
        object _value = null;
        object IFoo.Value
        {
            get { return _value; }
            set { _value = value; }
        }
    
        public T Value
        {
            get;
            set;
        }
    }
