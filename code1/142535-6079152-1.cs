    public class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var dt = new DataTable();
            dt.Columns.Add("Column1", typeof(string));
            dt.Columns.Add("Column2", typeof(int));
            for (int i = 1; i <= 5; i++)
            {
                dt.Rows.Add("Value " + i.ToString(), i);
            }
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Column1";
            comboBox1.ValueMember = "Column2";
        }
    }
