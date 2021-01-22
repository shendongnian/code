    // This class exists to encapsulate the INotifyPropertyChanged requirements
    public class ChangeNotifyBase : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    public class Foo : ChangeNotifyBase
    {
        public Foo()
        {
            Bar = new Bar();
            var binding = new Binding("Bar.Baz.It");
            binding.Source = this;
            binding.Mode = BindingMode.TwoWay;
            BindingOperations.SetBinding(this, ItGetterProperty, binding);
        }
        /// <summary>
        /// The ItGetter dependency property.
        /// </summary>
        public bool ItGetter
        {
            get { return (bool)GetValue(ItGetterProperty); }
            set { SetValue(ItGetterProperty, value); }
        }
        public static readonly DependencyProperty ItGetterProperty =
            DependencyProperty.Register("ItGetter", typeof(bool), typeof(Foo));
        // Must do the OnPropertyChanged to notify the dependency machinery of changes.
        private Bar _bar;
        public Bar Bar { get { return _bar; } set { _bar = value; OnPropertyChanged("Bar"); } }
    }
    public class Bar : ChangeNotifyBase
    {
        public Bar()
        {
            Baz = new Baz();
        }
        private Baz _baz;
        public Baz Baz { get { return _baz; } set { _baz = value; OnPropertyChanged("Baz"); } }
    }
    public class Baz : ChangeNotifyBase
    {
        private bool _it;
        public bool It { get { return _it; } set { _it = value; OnPropertyChanged("It"); } }
    }
