    public Form2()
        {
            InitializeComponent();
            this.Load += new EventHandler(centerLabel);
            this.Resize += new EventHandler(centerLabel);
        }
        protected void centerLabel(object sender,EventArgs e)
        {
            this.label1.Location = new Point(this.Width / 2, this.Height / 2);
        }
