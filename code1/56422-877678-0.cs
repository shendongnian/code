    public partial class Form1 : Form
    {
        private DataTable table;
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(HandleEditingControlShowing);
            this.table = new DataTable();
            table.Columns.Add("Column");
            table.Rows.Add("Row 1");
            this.dataGridView1.DataSource = table;
        }
        private void HandleEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            var ctl = e.Control as DataGridViewTextBoxEditingControl;
            if (ctl == null)
            {
                return;
            }
            ctl.KeyDown -= ctl_KeyDown;
            ctl.KeyDown += new KeyEventHandler(ctl_KeyDown);
        }
        private void ctl_KeyDown(object sender, KeyEventArgs e)
        {
            var box = sender as TextBox;
            if (box == null)
            {
                return;
            }
            if (e.KeyCode == Keys.F2)
            {
                this.dataGridView1.EndEdit();
                MessageBox.Show(box.Text);
            }
        }
