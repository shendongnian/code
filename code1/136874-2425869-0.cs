public void BindData(DataTable dt)
{
    rpt.DataSource = dt;
    rpt.DataBind();
}
