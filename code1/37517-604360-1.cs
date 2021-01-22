    public partial class Form1 : Form
    {
        DataGridViewCellStyle _myStyle = new DataGridViewCellStyle();
        public Form1()
        {
            InitializeComponent();
            _myStyle.BackColor = Color.Pink;
            // We could also provide a custom format string here 
            // with the _myStyle.Format property
        }
        private void dataGridView1_CellFormatting(object sender, 
            DataGridViewCellFormattingEventArgs e)
        {
            // Every five rows I want my custom format instead of the default
            if (e.RowIndex % 5 == 0)
            {
                e.CellStyle = _myStyle;
                e.FormattingApplied = true;
            }
        }
        //...
    }
