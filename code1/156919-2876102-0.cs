protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.Footer)
    {
      // Connect
      // Build query
      // Execute data reader
      // Bind data
      e.Row.Cells[0].Text = reader["somedata"].ToString();
      e.Row.Cells[1].Text = reader["someotherdata"].ToString();
      // Close reader and connection
     }
}
