    StringBuilder sb = new SringBuilder();
    
    sb.AppendLine("<table>");
    sb.AppendLine("  <tr>");
    foreach(DataGridViewColumn column in grid.Columns)
    {
      sb.AppendLine("    <td>" + column.HeaderText + "</td>");
    }
    sb.AppendLine("  </tr>");    
    
    foreach(DataGridViewRow row in grid.Rows)
    {
      sb.AppendLine("  <tr>");
      foreach(DataGridViewCell cell in row.Cells)
      {
        sb.AppendLine("    <td width=\"" + cell.Width + "px\">" + cell.Value + "</td>");
      }
      sb.AppendLine("  </tr>");
    }
    sb.AppendLine("</table>");
