    private void GridView_CustomDrawEvent(object sender, RowCellCustomDrawEventArgs e)
    {
        if(e.Column.FieldName == "CreationDate")
        {
            string date = 
                ((DateTime) view.GetRowCellValue(e.RowHandle, "CreationDate")).ToShortDateString();
            string time = 
                ((DateTime) view.GetRowCellValue(e.RowHandle, "CreationDate")).ToLongTimeString();
            string displayDate = date + " " time;
            e.DisplayText = displayDate;
        }
    }
