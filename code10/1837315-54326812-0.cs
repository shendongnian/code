    if (e.Row.RowType == DataControlRowType.DataRow)
        {
           PartEnquiryLine line = (PartEnquiryLine)e.Row.DataItem;
           Label lbl = (Label)e.Row.FindControl("lblStockDetails");
           if (line.StatusText == Text["280"])
           {
                   lbl.Text = Text["290"]
                
                    e.Row.Cells.RemoveAt(2);
                    e.Row.Cells.RemoveAt(3);
                    e.Row.Cells[4].ColSpan = 9;
                    e.Row.Cells.RemoveAt(5);
                    e.Row.Cells.RemoveAt(6);
                    e.Row.Cells.RemoveAt(7);
                    e.Row.Cells.RemoveAt(8);
                    e.Row.Cells.RemoveAt(9);
                    e.Row.Cells.RemoveAt(10);
         }
