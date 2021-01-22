     protected void GVKeywordReport_RowDataBound(object sender, GridViewRowEventArgs e)
            {
               
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRow pr = ((DataRowView)e.Row.DataItem).Row;
                    int oldPos = Convert.ToInt32(pr["oldposition"]);
                    int newPos = Convert.ToInt32(pr["newposition"]);
                    GVKeywordReport.HeaderRow.Cells[3].Text = txtfrmdate.Text;
                    GVKeywordReport.HeaderRow.Cells[4].Text = txtEndDate.Text;
    
                    GVKeywordReport.HeaderRow.BackColor = ColorTranslator.FromHtml("#B3B300");
                    e.Row.Cells[0].BackColor = ColorTranslator.FromHtml("#B3B300");
                    e.Row.Cells[5].BackColor = ColorTranslator.FromHtml("#FFFFFF");
    
                    if (oldPos == newPos)
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#FF950E");
                        e.Row.Cells[6].Text = "No Change";
                    }
                    else if (oldPos > newPos)
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#FFFFCC");
                        e.Row.Cells[6].Text = "Improved";
                    }
                    else  
    
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#FF0000");
                        e.Row.Cells[6].Text = "Decreased";
                    }
                   // e.Row.Cells[0].BackColor = ColorTranslator.FromHtml("#7DA647");
                }
            }
