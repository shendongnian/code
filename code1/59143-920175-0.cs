        foreach(DataGridViewRow row in view.Rows)
        {
            IDataErrorInfo dei = row.DataBoundItem as IDataErrorInfo;
            if (dei != null && !string.IsNullOrEmpty(dei.Error))
            {
                view.FirstDisplayedScrollingRowIndex = row.Index;
                break;
            }
        }
