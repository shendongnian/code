    public partial class Form1 : Form
    {
        BackgroundWorker b = new BackgroundWorker();
        public Form1()
        {
            InitializeComponent();
            b.RunWorkerCompleted += new RunWorkerCompletedEventHandler(b_RunWorkerCompleted);
            b.DoWork += new DoWorkEventHandler(b_DoWork);
        }
        void b_DoWork(object sender, DoWorkEventArgs e)
        {
            // build dataset here and assigning it to results
            e.Result = dataset;            
        }
        void b_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // assign the dataset you built in DoWork in the gridview and update it
            dataGridView1.DataSource = e.Result;
            dataGridView1.Update();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            b.RunWorkerAsync();
        }
    }
