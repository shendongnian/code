    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ImageList imageList = new ImageList();
        Dictionary<string, Metadata> metadata = new Dictionary<string, Metadata>();
        private string dir = @"H:\temp";
        private void button1_Click(object sender, EventArgs e)
        {
            // You would set this in the designer, probably
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = imageList;
            // Make sure we start from the beginning
            listView1.Items.Clear();
            imageList.Images.Clear();
            metadata.Clear();
            // Add items
            for (int i = 0; i < 10; i++)
            {
                var filename = "1 ("+(i+1)+").png"; // Just strange names I have
                var fullFileName = Path.Combine(dir, filename);
                imageList.Images.Add(i.ToString(), Bitmap.FromFile(fullFileName));
                metadata.Add(i.ToString(), new Metadata{Path = fullFileName});
                listView1.Items.Add(i.ToString(), "Image " + i, i.ToString());
            }
            // Update view
            listView1.Refresh();
            listView1.Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < 6; i++)
            {
                var filename = "1 ("+(i+2)+").png";
                var fullFileName = Path.Combine(dir, filename);
                // Change image
                imageList.Images.RemoveByKey(i.ToString());
                imageList.Images.Add(i.ToString(), Bitmap.FromFile(fullFileName));
                // Match metadata and image
                metadata[i.ToString()] = new Metadata{Path = fullFileName};
            }
            listView1.Refresh();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var key = listView1.SelectedItems[0].ImageKey;
                label1.Text = metadata[key].Path;
            }
            else
            {
                label1.Text = "No image selected";
            }
        }
    }
    internal class Metadata
    {
        internal string Path;
    }
