    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            // NOTE: I forget the event / method names, these are probably a little wrong.
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (o, e) =>
            {
                Form2 f = new Form2();
                e.Result = f.ShowDialog();
            };
            worker.DoWorkComplete += (o, e) =>
            { 
                if(e.Error != null)
                    MessageBox.Show(string.Format("Caught Error: {0}", ex.Message));
                // else success!
                // use e.Result to figure out the dialog closed result.
            };
            worker.DoWorkAsync();
        }
    }
