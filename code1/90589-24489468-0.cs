    using System.Threading;
    using System.Threading.Tasks;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = new List<Test>() { new Test { Name = "Original Value" } };
        }
        // Start the a new Task to avoid blocking the UI Thread
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(this.UpdateGridView);
        }
        // Blocks the UI
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateGridView();
        }
        private void UpdateGridView()
        {
            //Simulate long running operation
            Thread.Sleep(3000);
            Action del = () =>
                {
                    dataGridView1.Rows[0].Cells[0].Value = "Updated value";
                };
            // If the caller is on a different thread than the one the control was created on
            // http://msdn.microsoft.com/en-us/library/system.windows.forms.control.invokerequired%28v=vs.110%29.aspx
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(del);
            }
            else
            {
                del();
            }
        }
    }
