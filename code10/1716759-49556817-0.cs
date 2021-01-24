        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
           
            bool IsGrandTotalRowNeedtoAdd = false;
              if ((strPreviousRowID != string.Empty) && (DataBinder.Eval(e.Row.DataItem, "city_name") == null))
            {
               
                IsGrandTotalRowNeedtoAdd = true;
                intTotalIndex = 0;
            }
            if (IsGrandTotalRowNeedtoAdd)
            {
                GridView grdViewProducts = (GridView)sender;
                GridViewRow GrandTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
                GrandTotalRow.Font.Bold = true;
                GrandTotalRow.BackColor = System.Drawing.Color.LightPink;
                GrandTotalRow.ForeColor = System.Drawing.Color.White;
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Grand Total";
                HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Font.Bold = true;
                HeaderCell.ForeColor = System.Drawing.Color.Red;
                HeaderCell.Font.Size = 10;
                GrandTotalRow.Cells.Add(HeaderCell);
               // you can use how many fields you want to calculate
                HeaderCell = new TableCell();
                HeaderCell.Text = string.Format("{0:0.00}", GrandTotalCounter);
                HeaderCell.HorizontalAlign = HorizontalAlign.Right;
                HeaderCell.Font.Bold = true;
                HeaderCell.ForeColor = System.Drawing.Color.Red;
                HeaderCell.Font.Size = 10;
                GrandTotalRow.Cells.Add(HeaderCell);
                //////////////
                GrandTotalRow.Cells.Add(HeaderCell);
                grdViewProducts.Controls[0].Controls.AddAt(e.Row.RowIndex, 
              GrandTotalRow);
            }}
