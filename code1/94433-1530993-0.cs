    public partial class MasterForm : Form
    {
        private MyControl _MyControl = new MyControl();
    
        public MasterForm()
        {
            InitializeComponent();
        }
    
        public void Method1()
        {
            _MyControl.Method1();
        }
    }
