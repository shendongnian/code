    Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=gridSample.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
    
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                //to export all pages
                gridSample.AllowPaging = false;
                gridSample.DataSource = progress.getSample();
                gridSample.DataBind();
                //bind again
    
                gridSample.HeaderRow.BackColor = Color.White;
    
                foreach (TableCell cell in gridSample.HeaderRow.Cells)
                {
                    cell.BackColor = gridSample.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridSample.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridSample.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridSample.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }
    
                gridSample.RenderControl(hw);
    
                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
