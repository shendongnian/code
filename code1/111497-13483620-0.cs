    String filename = Path.Combine(Path.GetTempPath(), "grid.csv");
    using (Stream stream = new MemoryStream())
    {
        this.Grid.Export(stream,new GridViewExportOptions() {Format = ExportFormat.Csv, ShowColumnHeaders = true});
        stream.Position = 0;
        using (StreamReader r = new StreamReader(stream))
        {
            Clipboard.SetData(DataFormats.CommaSeparatedValue, r.ReadToEnd());
        }
    }
