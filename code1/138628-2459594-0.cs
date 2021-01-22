    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                    
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //test data
            this.dataGridView1.Rows.Add(1);
            this.dataGridView1[1, 0].Value = "testValue1";
            this.dataGridView1[1, 1].Value = "testValue2";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Button is in column 0.
            if ((e.ColumnIndex != 0) || (e.RowIndex < 0)) { return; }
            string valueToPass = (dataGridView1[1, e.RowIndex].Value as string) ?? String.Empty;
            Form2 f2 = new Form2(valueToPass);
            f2.Show();
        }
   
    }
    public partial class Form2 : Form
    {
        public Form2(string valueFromOtherForm)
        {
            InitializeComponent();
            this.textBox1.Text = valueFromOtherForm;
        }
        
    }
