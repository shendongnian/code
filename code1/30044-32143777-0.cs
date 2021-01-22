    public partial class App3DummyForm : Form
    {
        private readonly string[] _args;
        public App3DummyForm(string[] args)
        {
            _args = args;
            InitializeComponent();
        }
        private void App3DummyForm_Load(object sender, EventArgs e)
        {
            AllocConsole();
            App3.Program.OriginalMain(_args);
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
