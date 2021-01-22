    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            listView1.Columns[1].Width = 0;
            listView1.ColumnWidthChanging += listView1_ColumnWidthChanging;
        }
        private void listView1_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e) {
            if (e.ColumnIndex == 1) {
                e.NewWidth = 0;
                e.Cancel = true;
            }
        }
    }
