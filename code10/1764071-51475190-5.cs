    public partial class Form2 : Form
        {
            public ListView _listView { get; set; }
    
            public Form2()
            {
                InitializeComponent();
            }
    
            public Form2(ListView listView)
            {
                _listView = listView;
                InitializeComponent();
            }
    
            private void Form2_Load(object sender, EventArgs e)
            {
                listView1.Items.AddRange((from ListViewItem item in _listView.Items
                                          select (ListViewItem)item.Clone()).ToArray());
            }
        }
 
