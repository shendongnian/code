    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListViewItem lvi1 = new ListViewItem("1");
            lvi1.SubItems.Add(Guid.NewGuid().ToString());
            ListViewItem lvi2 = new ListViewItem("2");
            lvi2.SubItems.Add(Guid.NewGuid().ToString());
            ListViewEx lve = new ListViewEx();
            ColumnHeader headerID = lve.Columns.Add("ID");
            ColumnHeader headerGUID = lve.Columns.Add("GUID");
            lve.View = View.Details;
            Controls.Add(lve);
            lve.Size = new Size(100, 100);
            lve.Items.AddRange(new ListViewItem[] { lvi1, lvi2 });
        }
    }
