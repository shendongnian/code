        public Form1()
        {
            InitializeComponent();
            this.srvList.SelectedIndexChanged += new System.EventHandler(this.srvList_SelectedIndexChanged);
            mapBox1.Items.Add("Germany");
            mapBox1.Items.Add("Russia");
            difBox1.Items.Add("Easy");
            difBox1.Items.Add("Difficult");
        }
