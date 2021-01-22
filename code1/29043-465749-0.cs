    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = new testData[] {
                new testData{ CheckBox = true, Name = "One" },
                new testData{ CheckBox = true, Name = "Two" },
                new testData{ CheckBox = false, Name = "Three" },
                new testData{ CheckBox = false, Name = "Four" }            
            };
        }
    
        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0) // It's the Checkbox Column
            {
                DataGridViewRow dgvr = dgv.Rows[e.RowIndex];
                MessageBox.Show(String.Format("Row {0} was cliked ({1})", (e.RowIndex + 1).ToString(), 
                    dgvr.Cells[1].Value));
            }
        }
    }
    
    public class testData
    {
        public Boolean CheckBox { get; set; }
        public String Name { get; set; }
    }
