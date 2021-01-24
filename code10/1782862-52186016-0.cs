    public partial class CustomDateTimePicker : UserControl
    {
        private DateTime? _Time;
        public DateTime? Time
        {
            get { return _Time; }
            set
            {
                _Time = value;
                TimePicked();
            }
        }
        public CustomDateTimePicker()
        {
            InitializeComponent();
        }
        public void TimePicked()
        {
            if (_Time.HasValue)
            {
                MessageBox.Show(_Time.Value.ToString("hh:mm tt"));
            }
        }
    }
