    public partial class DoubleTrackBar : TrackBar
    {
        public DoubleTrackBar()
        {
            InitializeComponent();
        }
        private int _multiplier = 100;
        [Browsable(true)]
        public new double Minimum
        {
            get
            {
                return (double)base.Minimum / _multiplier;
            }
            set
            {
                base.Minimum = (int)(value * _multiplier);
            }
        }
        [Browsable(true)]
        public new double Maximum
        {
            get
            {
                return (double)base.Maximum / _multiplier;
            }
            set
            {
                base.Maximum = (int)(value * _multiplier);
            }
        }
        [Browsable(true)]
        public new double Value
        {
            get
            {
                return (double)base.Value / _multiplier;
            }
            set
            {
                base.Value = (int)(value * _multiplier);
            }
        }
        [Browsable(true)]
        public new double SmallChange
        {
            get
            {
                return (double)base.SmallChange / _multiplier;
            }
            set
            {
                base.SmallChange = (int)(value * _multiplier);
            }
        }
    }
