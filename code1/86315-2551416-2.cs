        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the current column details
            string strColumnName = dataGridView1.Columns[e.ColumnIndex].Name;
            SortOrder strSortOrder = getSortOrder(e.ColumnIndex);
            students.Sort(new StudentComparer(strColumnName, strSortOrder));
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = students;
            customizeDataGridView();
            dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = strSortOrder;
        }
       /// <summary>
        /// Get the current sort order of the column and return it
        /// set the new SortOrder to the columns.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns>SortOrder of the current column</returns>
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
