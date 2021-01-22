    private void ListViewHeaderWidth() {
            int HeaderWidth = (listViewInfo.Parent.Width - 2) / listViewInfo.Columns.Count;
            foreach (ColumnHeader header in listViewInfo.Columns)
            {
                header.Width = HeaderWidth;
            }
        }
