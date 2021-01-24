    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataGridView dataGridView1 = new DataGridView();
            this.Controls.Add(dataGridView1);
            dataGridView1.Columns.Clear();
            DataGridViewDateTimeColumn col = new DataGridViewDateTimeColumn();
            dataGridView1.Columns.Add(col);
        }
    }
