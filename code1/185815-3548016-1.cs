       ContentPlaceHolder ph = (ContentPlaceHolder)this.Master.FindControl( "ContentPlaceHolder1" );
    
       foreach (DataRow row in DataSet.Tables[0].Rows) {
          Panel pnl = new Panel();
          Table tbl = new Table();
          TableRow tblrow = new TableRow();
          TableCell cell1 = new TableCell();
          cell1.Text = string.Format("Site name: <b>{0}</b>",row["sitename"]);
          row.Cells.Add(cell1);
          tbl.Rows.Add(tblrow);
          pnl.Controls.Add(tbl);
          ph.Controls.Add(pnl);
       }
