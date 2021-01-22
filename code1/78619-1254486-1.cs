     protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
{
    DataTable dtbl = ((DataSet)Session["myDataSet"]).Tables[0];
    dtbl.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
    GridView1.DataSource = dtbl;
    GridView1.DataBind();
