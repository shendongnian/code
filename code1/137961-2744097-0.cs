    private void DataGrid1_SortCommand(object source, 
                           System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
       dgvBookInfo.Sort = e.SortExpression;
       DataGrid1.DataBind();
    }
