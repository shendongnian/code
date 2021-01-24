    public (HttpStatusCode code, string description) CreateInvoice(string PumpName, string customerCode, double fuelQty, double price)
    {
        HttpStatusCode retval = new HttpStatusCode();
        string errorDescription = string.Empty;
        SAPbobsCOM.Documents oInvoice = company.GetBusinessObject(BoObjectTypes.oInvoices);
        oInvoice.DocDate = DateTime.Now;
        oInvoice.CardCode = customerCode;
        oInvoice.Lines.ItemCode = "DSL";
        oInvoice.Lines.Quantity = fuelQty;
        oInvoice.Lines.LineTotal = price;
        oInvoice.Lines.Add();
        int addInvoice = oInvoice.Add();
        if (addInvoice == 0)
        {
            retval = HttpStatusCode.OK;
        }
        if (addInvoice < 0)
        {
            errorDescription = company.GetLastErrorDescription();
            retval = HttpStatusCode.NotModified;
        }
        return (code: retval, description: errorDescription);
    }
