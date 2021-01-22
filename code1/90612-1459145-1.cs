    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void btnFill_Click(object sender, EventArgs e)
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerAsync();
        }
    
        private delegate void AddItemToListViewDelegate(ListView view, ListViewItem item);
    
        private void AddItemToListView(ListView view, ListViewItem item)
        {
            if (InvokeRequired)
            {
                Invoke(new AddItemToListViewDelegate(AddItemToListView), new object[] { view, item });
                return;
            }
    
            view.Items.Add(item);
        }
    
        private delegate void ClearListViewItemsDelegate(ListView view);
    
        private void ClearListView(ListView view)
        {
            if (InvokeRequired)
            {
                Invoke(new ClearListViewItemsDelegate(ClearListView), new object[] { view });
                return;
            }
    
            view.Items.Clear();
        }
    
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                if (i == 0)
                    ClearListView(listView1);
    
                var item = new ListViewItem();
                item.Name = i.ToString();
                item.Text = item.Name;
                AddItemToListView(listView1, item);
            }
        }
    }
