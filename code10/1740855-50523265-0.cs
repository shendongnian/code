    public partial class Suwak : UserControl
    {
        public Suwak()
        {
            InitializeComponent();
        }
        public int TrackBarMinium
        {
            get { return trackBar3.Minimum; }
            set { trackBar3.Minimum = value; }
        }
        ...
