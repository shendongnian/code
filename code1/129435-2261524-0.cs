    void ExportCsvAttachment(IEnumerable<Customer> customers)
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        Response.AddHeader("Content-Disposition: attachment;filename=Customers.csv");
        using (StreamWriter writer = new StreamWriter(Response.OutputStream))
        {
            WriteCsv(writer, customers);
        }
        Response.End();
    }
    void WriteCsv(TextWriter writer, IEnumerable<Customer> customers)
    {
        foreach (Customer cust in customers)
        {
            writer.Write(cust.ID);
            writer.Write(',');
            WriteCsvString(writer, cust.Name);
            writer.Write(',');
            WriteCsvString(writer, cust.PhoneNumber);
        }
    }
    void WriteCsvString(TextWriter writer, string s)
    {
        writer.Write('"');
        writer.Write(s.Replace("\"", "\"\""));
        writer.Write('"');
    }
