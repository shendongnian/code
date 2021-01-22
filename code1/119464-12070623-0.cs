        void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string value1 = dataGridView1.Rows[e.RowIndex1].Cells[e.Column.Index].FormattedValue.ToString();
            string value2 = dataGridView1.Rows[e.RowIndex2].Cells[e.Column.Index].FormattedValue.ToString();
            
            // Console.WriteLine(String.Format("CustomSort '{0}' - '{1}'", value1, value2));
            
            e.SortResult = System.String.Compare(
                value1.ToString(), value2.ToString());
            e.Handled = true;
        }
