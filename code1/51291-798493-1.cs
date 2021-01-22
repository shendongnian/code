    public partial class MainForm : Form
    {
        private static MainForm singletonInstance;
    
        public static MainForm SingletonInstance
        {
            get { return singletonInstance; }
        }
    
        public MainForm() : base()
        {
            InitializeComponent();
    
            singletonInstance = this;
        }
    }
    public void PerformActionOnForm(Action<FormMain> action)
    {
        var form = MainForm.SingletonInstance;
        // object s = action.Clone(); What was this for?
        if (form != null)
        {
            form.PerformAction(action);
        }
    }
