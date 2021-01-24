    using DevExpress.XtraReports.UI;
    
    // ...
    
    
    
    private void Detail_BeforePrint(object sender, PrintEventArgs e) {
    
       // Create a new table cell and set its text and width.
    
       XRTableCell tableCell = new XRTableCell();
    
       tableCell.Text = "NewCell";
    
       tableCell.Width = 200;
    
    
    
       // Suspend the table's layout.
    
       xrTable1.SuspendLayout();
    
    
    
       // Change the table.
    
       xrTable1.Width = xrTable1.Width + tableCell.Width;
    
       ((XRTableRow)xrTable1.Rows[0]).Cells.Add(tableCell);
    
    
    
       // Perform the table's layout.
    
       xrTable1.PerformLayout();
    
    }
