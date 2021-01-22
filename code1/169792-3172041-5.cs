    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
    
            // create fake items list
            List<string> strings = new List<string>();
            for (int i = 0; i < 36; i++)
                strings.Add("ITEM " + (i+1));
            var listViewItems = strings.Select(x => new ListViewItem(x, 0)).ToArray();
    
            // create a new list view
            ListView listView = new ListView();
            listView.View = View.SmallIcon;
            listView.SmallImageList = imageList1;
            listView.MultiSelect = false;
    
            // add items to listview
            listView.Items.AddRange(listViewItems);
    
            // calculate size of list from the listViewItems' height
            int itemToShow = 18;
            var lastItemToShow = listViewItems.Take(itemToShow).Last();
            int height = lastItemToShow.Bounds.Bottom + listView.Margin.Top;
            listView.Height = height;
    
            // create a new popup and add the list view to it
            var popup = new ToolStripDropDown();
            popup.AutoSize = false;
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            ToolStripControlHost host = new ToolStripControlHost(listView);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = listView.Size;
            popup.Size = listView.Size;
            popup.Items.Add(host);
    
            // show the popup
            popup.Show(this, button.Left, button.Bottom);
        }
    }
