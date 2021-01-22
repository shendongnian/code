    public partial class Form1 : BaseForm
        {
            BindingSource source = new BindingSource();
            public Form1()
            {
                InitializeComponent();
                this.dataGridView1.DataSource = source;
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataTable table = GetDataTable();
                this.source.DataSource = table;
            }
        }
    
        public class BaseForm : Form
        {
            protected DataTable GetDataTable()
            {
                DataTable result = new DataTable();
                result.Columns.Add("Name");
                result.Columns.Add("Age", typeof(int));
                result.Rows.Add("Alex", 27);
                return result;
            }
        }
