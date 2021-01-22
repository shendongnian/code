    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            for (int page = 0; page < tabControl1.TabCount; ++page)
                tabControl1.TabPages[page].Tag = page;
        }
        private List<TabPage> hiddenPages = new List<TabPage>();
        public void ShowTab(TabPage page) {
            int pos = (int)page.Tag;
            int insertPoint;
            for (insertPoint = 0; insertPoint < tabControl1.TabCount; ++insertPoint) {
                if (pos <= (int)tabControl1.TabPages[insertPoint].Tag) break;
            }
            tabControl1.TabPages.Insert(insertPoint, page);
            hiddenPages.Remove(page);
        }
    }
