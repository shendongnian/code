    public partial class MainWindow : Window {
        class DiffItem {
            public int diff { get; set; } // used to color grid row (highlight differences)
            public string leftString { get; set; }
            public string rightString { get; set; }
        }
        public BitmapImage overview { get; set; }
        public MainWindow() {
            InitializeComponent();
            DataContext = this;
            // build a lengthy list for demonstration
            List<DiffItem> diffList = new List<DiffItem>();
            for (int i = 0; i < 10; i++) {
                diffList.Add(new DiffItem() { diff = 0, leftString = "one", rightString = "one" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "two", rightString = "two" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "three", rightString = "three" });
                diffList.Add(new DiffItem() { diff = -1, leftString = "four", rightString = "" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "five", rightString = "five" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "six", rightString = "six" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "seven", rightString = "seven" });
                diffList.Add(new DiffItem() { diff = 1, leftString = "", rightString = "eight" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "nine", rightString = "nine" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "ten", rightString = "ten" });
                diffList.Add(new DiffItem() { diff = 2, leftString = "eleven", rightString = "elven" });
                diffList.Add(new DiffItem() { diff = 2, leftString = "twelv", rightString = "twelve" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "thirteen", rightString = "thirteen" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "fourteen", rightString = "fourteen" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "fifteen", rightString = "fifteen" });
                diffList.Add(new DiffItem() { diff = 0, leftString = "sixteen", rightString = "sixteen" });
            }
            // display list
            dgDiffs.ItemsSource = diffList;
            // create the overview bitmap
            Bitmap bmp = new Bitmap(20, 200, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Pen greenPen = new Pen(Color.Green, 1);
                g.Clear(Color.White);
                g.DrawLine(greenPen, 0, 50, 20, 50);
            }
            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            // load scrollbar with overview
            overview = new BitmapImage();
            overview.BeginInit();
            overview.StreamSource = memoryStream;
            overview.EndInit();
            overview.Freeze();
        }
    }
