    public partial class MainForm : Form
    {
        private Sample sampleUserControl = new Sample();
        public MainForm()
        {
            this.InitializeComponent();
            sampleUserControl.TextboxValidated += new EventHandler(this.CustomEvent_Handler);
        }
        private void CustomEvent_Handler(object sender, EventArgs e)
        {
            // do stuff
        }
    }
