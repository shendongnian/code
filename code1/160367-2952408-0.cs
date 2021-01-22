    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { lock (this.mHandler) { this.mHandler.PropertyChanged += value; } }
            remove { lock (this.mHandler) { this.mHandler.PropertyChanged -= value; } }
        }
        public bool CheckboxIsChecked
        {
            get { return this.mHandler.CheckboxIsChecked; }
            set { this.mHandler.CheckboxIsChecked = value; }
        }
        private HandlesPropertyChangeEvents mHandler = new HandlesPropertyChangeEvents();
        public MainWindow()
        {
            InitializeComponent();
            this.mHandler.Sender = this;
        }
        public class HandlesPropertyChangeEvents : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public Sender { get; set; }
            public bool CheckboxIsChecked
            {
                get { return this.mCheckboxIsChecked; }
                set
                {
                    this.mCheckboxIsChecked = value;
                    PropertyChangedEventHandler handler = this.PropertyChanged;
                    if (handler != null)
                        handler(this.Sender, new PropertyChangedEventArgs("CheckboxIsChecked"));
                }
            }
            private bool mCheckboxIsChecked = false;
        }
    }
