    private void GridView_CustomDrawEvent(object sender, RowCellCustomDrawEventArgs e)
    {
        if(e.Column.FieldName == "CreationDate")
        {
            string date = ((DateTime) view.GetRowCellValue(e.RowHandle, "CreationDate"));
            string displayDate = date.ToShortDateString() + " " time.ToLongTimeString();
            e.DisplayText = displayDate;
        }
    }
