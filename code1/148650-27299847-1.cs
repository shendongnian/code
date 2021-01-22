    var lr = new LocalReport
    {
        ReportPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? @"C:\", "Reports", "PathOfMyReport.rdlc"),
        EnableExternalImages = true
    };
    lr.DataSources.Add(new ReportDataSource("NameOfMyDataSet", model));
    string mimeType, encoding, extension;
    Warning[] warnings;
    string[] streams;
    var renderedBytes = lr.Render
        (
            "PDF",
            @"<DeviceInfo><OutputFormat>PDF</OutputFormat><HumanReadablePDF>False</HumanReadablePDF></DeviceInfo>",
            out mimeType,
            out encoding,
            out extension,
            out streams,
            out warnings
        );
    var saveAs = string.Format("{0}.pdf", Path.Combine(tempPath, "myfilename"));
    var idx = 0;
    while (File.Exists(saveAs))
    {
        idx++;
        saveAs = string.Format("{0}.{1}.pdf", Path.Combine(tempPath, "myfilename"), idx);
    }
    using (var stream = new FileStream(saveAs, FileMode.Create, FileAccess.Write))
    {
        stream.Write(renderedBytes, 0, renderedBytes.Length);
        stream.Close();
    }
    lr.Dispose();
