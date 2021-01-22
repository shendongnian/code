    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Color[] backgroundColors = new[] { Color.Green, Color.White, Color.Blue };
            Color[] foregroundColors = new[] { Color.Black, Color.Red, Color.Yellow };
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Color backgroundColor = backgroundColors[random.Next(0, 3)];
                Color foregroundColor = foregroundColors[random.Next(0, 3)];
                ListViewItem listViewItem = listView1.Items.Add(foregroundColor.Name);
                listViewItem.SubItems.Add(backgroundColor.Name);
                listViewItem.SubItems.Add(Guid.NewGuid().ToString());
                listViewItem.BackColor = backgroundColor;
                listViewItem.ForeColor = foregroundColor;
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewItemComparer listViewItemComparer = new ListViewItemComparer {SortColumn = e.Column, Sorting = SortOrder.Ascending};
            if (listView1.ListViewItemSorter is ListViewItemComparer)
            {
                ListViewItemComparer listViewItemComparerOld = listView1.ListViewItemSorter as ListViewItemComparer;
                if (listViewItemComparerOld != null && listViewItemComparerOld.SortColumn == e.Column)
                {
                    listViewItemComparer.Sorting = (listViewItemComparerOld.Sorting == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
                }
            }
            listView1.ListViewItemSorter = listViewItemComparer;
            listView1.Sort();
        }
        #region ListViewItemComparer
        public class ListViewItemComparer : IComparer
        {
            #region Public Properties
            public int SortColumn { get; set; }
            public SortOrder Sorting { get; set; }
            #endregion
            public ListViewItemComparer()
            {
                SortColumn = 0;
                Sorting = SortOrder.Ascending;
            }
            public int Compare(object x, object y)
            {
                ListViewItem listViewItem1 = null;
                ListViewItem listViewItem2 = null;
                string compare1 = string.Empty;
                string compare2 = string.Empty;
                if (Sorting == SortOrder.Ascending)
                {
                    listViewItem1 = (ListViewItem)x; listViewItem2 = (ListViewItem)y;
                }
                if (Sorting == SortOrder.Descending)
                {
                    listViewItem1 = (ListViewItem)y; listViewItem2 = (ListViewItem)x;
                }
                if (listViewItem1 != null && (SortColumn < listViewItem1.SubItems.Count) && (listViewItem1.SubItems[SortColumn] != null))
                {
                    compare1 = listViewItem1.SubItems[SortColumn].Text;
                }
                if (listViewItem2 != null && (SortColumn < listViewItem1.SubItems.Count) && (listViewItem2.SubItems[SortColumn] != null))
                {
                    compare2 = listViewItem2.SubItems[SortColumn].Text;
                }
                return string.Compare(compare1, compare2);
            }
        }
        #endregion
    }
