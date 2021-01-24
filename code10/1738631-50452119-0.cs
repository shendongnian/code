    public partial class Loading_Screen : Form
    {
        public Loading_Screen()
        {
            InitializeComponent();
        }
        public Action Worker { get; set; }
        public Loading_Screen(Action worker)
        {
            InitializeComponent();
            Worker = worker ?? throw new ArgumentOutOfRangeException();
        }
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await Task.Factory.StartNew(Worker);
            Close();
        }
    }
