    private void rgv_orderLines_CellFormatting(object sender, CellFormattingEventArgs e)
    {
        if (e.CellElement.ColumnInfo.Name == "Moved so Far")
        {
            if(e.CellElement.Value != null)
            {
                string value = e.CellElement.Value.ToString();
                value = value.Replace("-", "");
                e.CellElement.Value = value;
            }
        }
    }
