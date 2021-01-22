protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
{
  if (e.Row.RowType == DataControlRowType.DataRow)
  {
    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
    e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
    e.Row.Attributes.Add("style", "cursor:pointer;");
    e.Row.Attributes.Add("onclick", "location='patron_detail.aspx?id=" + e.Row.Cells[0].Text + "'");
  }
}</pre>
