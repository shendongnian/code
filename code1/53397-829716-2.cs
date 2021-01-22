    public partial class MyForm : Form
    {
        private static MyForm instance;
    
        public static MyForm Instance
        {
            get { return instance; }
        }
    
        public MyForm() : base()
        {
            InitializeComponent();
    
            // ....
    
            instance = this;
        }
    }
