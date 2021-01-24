       foreach(DataRow displayRow in ((DataView)dialog.displayTable.ItemsSource).ToTable().Rows)
        {
            int i = 0;
            DataRow drNew = displayTable.NewRow();
            foreach (DataGridColumn selectedCol in dialog.SelectionTable.Columns)
            {
                
                drNew[(selectedCol.Header as ComboBox).SelectedIndex] = displayRow[i];
                i++;
            }
            displayTable.Rows.Add(drNew.ItemArray);
        }
