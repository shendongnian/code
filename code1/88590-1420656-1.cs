protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
...
e.Row.Attributes.Add("onclick", "javascript:__doPostBack('" + GridView1.ClientID + "','SelectCommand$" + e.Row.RowIndex.ToString() + "')")
...
}
protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
{
  if (e.CommandName == "SelectCommand") {
    // ...
  }
}
