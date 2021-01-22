        private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            string cell1, cell2;
            if (e.Column == "Your_Column")
            {
                if (e.CellValue1 == null) cell1 = "";
                else cell1 = e.CellValue1.ToString();
                if (e.CellValue2 == null) cell2 = "";
                else cell2 = e.CellValue2.ToString();
                if (cell1 == "Account Manager") { e.SortResult = -1; e.Handled = true; }
                else
                {
                    if (cell2 == "Account Manager") { e.SortResult = 1; e.Handled = true; }
                    else
                    {
                        if (cell1 == "Assistant Account Manager") { e.SortResult = -1; e.Handled = true; }
                        else
                        {
                            if (cell2 == "Assistant Account Manager") { e.SortResult = 1; e.Handled = true; }
                        }
                    }
                }
            }
        }
