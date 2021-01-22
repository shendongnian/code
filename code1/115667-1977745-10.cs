        // Event hander that accepts a parameter of the EventArgs type.
        private void MultiHandler(object sender, System.EventArgs e)
        {
           label1.Text = System.DateTime.Now.ToString();
        }
        public Form1()
        {
            InitializeComponent();
            // You can use a method that has an EventArgs parameter,
            // although the event expects the KeyEventArgs parameter.
            this.button1.KeyDown += this.MultiHandler;
            // You can use the same method 
            // for an event that expects the MouseEventArgs parameter.
            this.button1.MouseClick += this.MultiHandler;
         }
