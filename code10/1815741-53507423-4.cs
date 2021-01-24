    using System.ComponentModel;
    private BackgroundWorker _worker;
    
        public Form1()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += (sender, args) =>
            {
                //i do something
            };
            _worker.RunWorkerCompleted += (sender, args) =>
            {
                MessageBox.Show("Done!");
                button1.Enabled = true;
            };
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _worker.RunWorkerAsync(e);
        }
