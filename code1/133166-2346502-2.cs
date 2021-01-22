    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
         DataTable dataTable = GridView1.DataSource as DataTable;
         if (dataTable != null)
         {
              DataView dataView = new DataView(dataTable);
              dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);
              GridView1.DataSource = dataView;
              GridView1.DataBind();
         }
    }
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
         string newSortDirection = String.Empty;
         switch (sortDirection)
         {
              case SortDirection.Ascending:
                  newSortDirection = "ASC";
              break;
              case SortDirection.Descending:
                  newSortDirection = "DESC";
              break;
         }
         return newSortDirection;
    }
