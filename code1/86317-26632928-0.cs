        private List<CompareInfo> compareList;
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
            if (strSortOrder == SortOrder.Ascending)
            {
                compareList = compareList.OrderBy(x => typeof(CompareInfo).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            else
            {
                compareList = compareList.OrderByDescending(x => typeof(CompareInfo).GetProperty(strColumnName).GetValue(x, null)).ToList();
            }
            dataGridView1.DataSource = compareList;
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }
        private SortOrder getSortOrder(int columnIndex)
        {
            if (dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.None ||
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending)
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
                return SortOrder.Ascending;
            }
            else
            {
                dataGridView1.Columns[columnIndex].HeaderCell.SortGlyphDirection = SortOrder.Descending;
                return SortOrder.Descending;
            }
        }
    
    public class CompareInfo
    {
        public string FileName { get; set; }
        public string UAT_Folder { get; set; }
        public string UAT_Path
        {
            get { return UAT_Folder + FileName; }
        }
        public string PROD_Folder { get; set; }
        public string PROD_Path
        {
            get { return PROD_Folder + FileName; }
        }
    }
