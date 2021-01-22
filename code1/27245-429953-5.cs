    string CurCustomerName;
    Decimal CustomerSalesTotal;
    DataSet ds = GetReportData();
    DataRowCollection r = ds.Tables[0].Rows;
    int i=0;
    while (i<r.Count)
    {
        CurCustomerName = r[i]["CustName"];
        CustomerSalesTotal = 0;
        PrintHeaderLine(CurCustomerName);
        while (i<r.Count && CurCustomerName == r[i]["CustName"])
        {
            PrintItemLine(r[i]["OrderTotal"]);
            CustomerSalesTotal += r[i]["OrderTotal"];
            i++;
        }
        PrintSubTotalLine(CustomerSalesTotal);
    }
    
