    public class Example : ExampleBase
    {
        private int _property;
        public override int Property { get { return _property; } }
        public void SetProperty(int property)
        {
            _property = property;
        }
    }
    public abstract class ExampleBase
    {
        public abstract int Property { get; }
    }
