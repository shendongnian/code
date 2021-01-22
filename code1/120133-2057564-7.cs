        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                String headerText = cell.Text;
                cell.Attributes.Add("title", headerTooltips[cell.Text]);
            }
        }
