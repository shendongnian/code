    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        protected override void SetVisibleCore(bool value)
        {
            // You'd probably want to parse the command line.
            if (Environment.CommandLine.Contains("/hide"))
                base.SetVisibleCore(false);
            else
                base.SetVisibleCore(value);
        }
    }
