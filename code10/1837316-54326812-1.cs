    if (e.Row.RowType == DataControlRowType.DataRow)
        {
           PartEnquiryLine line = (PartEnquiryLine)e.Row.DataItem;
           Label lbl = (Label)e.Row.FindControl("lblStockDetails");
           if (line.StatusText == Text["280"])
           {
                   lbl.Text = Text["290"]
                
                    e.Row.Cells[2].Visible = false;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].ColumnSpan = 9;
                    e.Row.Cells[5].Visible = false;;
                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;;
                    e.Row.Cells[10].Visible = false;
         }
