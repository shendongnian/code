protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
...
e.Row.Attributes.Add("onclick", "__doPostBack('" + GridView1.ClientID + "','Select$" + e.Row.RowIndex.ToString() + "')")
...
}
protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
{
  ...
}
