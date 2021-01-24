    public static DataTable dtProjectLedgerExport(DataTable dtToExport)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Supplier");
        dt.Columns.Add("Supplier_No");
        dt.Columns.Add("Confirmation_Number");
        dt.Columns.Add("Release_Number");
        dt.Columns.Add("WCO_Invoice_No");
        dt.Columns.Add("WCO_Invoice_Date");
        dt.Columns.Add("Customer_Billed_Amt");
        dt.Columns.Add("Balance_Remaining_to_Bill");
        dt.Columns.Add("Supplier_Invoice_Number");
        dt.Columns.Add("Supplier_Invoice_Date");
        dt.Columns.Add("Supplier_Paid_Amt");
        dt.Columns.Add("Remaining_Cost_Dollar_Balance");
        
        foreach (var expRow in dtToExport.Rows)
        {
            var row = dt.NewRow();
            row["Supplier"] = expRow["Supplier_Name"];
            //repeat for all columns you want.
            dt.Rows.Add(row);
        }
        return dt;
    }
