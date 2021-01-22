        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            foreach (Control control in this.Controls)
            {
                control.EnableDoubleBuferring();
            }
        }
