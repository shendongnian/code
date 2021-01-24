    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
    //open file and returns as Stream
    using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
    {
          using (var reader = ExcelReaderFactory.CreateReader(stream))
          {
          }
    }
