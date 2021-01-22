    public partial class Window1 : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Window1()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private double scaleValue = 1;
        public double ScaleValue
        {
            get
            {
                return scaleValue;
            }
            set
            {
                scaleValue = value;
                NotifyPropertyChanged("ScaleValue");
                NotifyPropertyChanged("ScaleValue2");
            }
        }
        public double ScaleValue2
        {
            get
            {
                return slider.Maximum - ScaleValue;
            }
        }
    }
