    public Form1()
        {
            InitializeComponent();
            this.panel1.MouseWheel += new MouseEventHandler(panel1_MouseWheel);
            this.panel1.MouseMove += new MouseEventHandler(panel1_MouseWheel);    
        }
