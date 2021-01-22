    public abstract class BaseClass
    {
        public abstract int Bar { get; }
    }
    public class ConcreteClass : BaseClass
    {
        private int _bar;
        public override int Bar
        {
            get { return _bar; }
        }
        public void SetBar(int value)
        {
            _bar = value;
        }
    }
