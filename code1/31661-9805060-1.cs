    public class SomeWindow: ChildWindow
    {
        private SomeViewModel _someViewModel;
        public SomeWindow()
        {
            InitializeComponent();
            this.Loaded += SomeWindow_Loaded;
            this.Closed += SomeWindow_Closed;
        }
        void SomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _someViewModel = this.DataContext as SomeViewModel;
            _someViewModel.PropertyChanged += _someViewModel_PropertyChanged;
        }
        void SomeWindow_Closed(object sender, System.EventArgs e)
        {
            _someViewModel.PropertyChanged -= _someViewModel_PropertyChanged;
            this.Loaded -= SomeWindow_Loaded;
            this.Closed -= SomeWindow_Closed;
        }
        void _someViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == SomeViewModel.DialogResultPropertyName)
            {
                this.DialogResult = _someViewModel.DialogResult;
            }
        }
    }
