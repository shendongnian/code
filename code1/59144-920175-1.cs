        foreach(DataGridViewRow row in view.Rows)
        {
            IDataErrorInfo dei = row.DataBoundItem as IDataErrorInfo;
            if (dei != null && !string.IsNullOrEmpty(dei.Error))
            {
                if(row.Cells.Count > 0) view.CurrentCell = row.Cells[0];
                view.FirstDisplayedScrollingRowIndex = row.Index;
                break;
            }
        }
