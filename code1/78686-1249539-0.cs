    public class ObservableClass
    {
        private Int32 _Value;
        public Int32 Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnValueChanged();
                }
            }
        }
        public event EventHandler ValueChanged;
        protected void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }
    }
    public class ObserverClass
    {
        public ObserverClass(ObservableClass observable)
        {
            observable.ValueChanged += TheValueChanged;
        }
        private void TheValueChanged(Object sender, EventArgs e)
        {
            Console.Out.WriteLine("Value changed to " +
                ((ObservableClass)sender).Value);
        }
    }
    public class Program
    {
        public static void Main()
        {
            ObservableClass observable = new ObservableClass();
            ObserverClass observer = new Observer(observable);
            observervable.Value = 10;
        }
    }
