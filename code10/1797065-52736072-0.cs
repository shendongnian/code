        readonly Methods Methods;
        public Main()
        {
            InitializeComponent();
            this.Methods = new Methods(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Methods.Info();  // not working
            Methods.Liste(); // not working
        }
