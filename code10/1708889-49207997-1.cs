    using CsvHelper;
    byte[] bin;
    
    using (MemoryStream stream = new MemoryStream())
    using (TextWriter textWriter = new StreamWriter(stream))
    using (CsvWriter csv = new CsvWriter(textWriter))
    {
        csv.Configuration.QuoteAllFields = true;
        csv.Configuration.TrimHeaders = true;
        csv.Configuration.TrimFields = true;
    
        csv.WriteRecords(MyList);
        bin = stream.ToArray();
    }
    
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    Response.ContentType = "text/csv; charset=utf-8";
    Response.AppendHeader("Content-disposition", string.Format("attachment; filename=\"{0}\"", "MyFile.csv"));
    Response.AppendHeader("Content-Length", bin.Length.ToString());
    Response.BinaryWrite(bin);
    Response.Flush();
    HttpContext.Current.ApplicationInstance.CompleteRequest();
