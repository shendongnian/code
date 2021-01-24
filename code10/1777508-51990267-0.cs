    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDgv();
    
            // detect each button font family
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                Debug.WriteLine(dataGridView1.Rows[i].Cells["button"].Style.Font.FontFamily.ToString());
            }
        }
    
        private void LoadDgv()
        {
            dataGridView1.Columns.Add("btns", "BTNS");
            FontFamilyCB.DisplayMember = "Name";
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "button";
                button.HeaderText = "Button";
                button.Text = "Button";
                dataGridView1.Columns.Add(button);
            }
            foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
            {
                FontFamilyCB.Items.Add(font);
    
                DataGridViewButtonCell b = new DataGridViewButtonCell();
    
                int rowIndex = dataGridView1.Rows.Add(b);
                dataGridView1.Rows[rowIndex].Cells["button"].Style.Font = new Font(font, 11, FontStyle.Regular);
                // each cell will have his own font-family
                dataGridView1.Rows[rowIndex].Cells["button"].Value = "A";
            }
        }
    }
