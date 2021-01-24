    public CsvOutputContext(
       ODataFormat format,
       ODataMessageWriterSettings settings,
       ODataMessageInfo messageInfo,
       bool synchronous)
       : base(format, settings, messageInfo.IsResponse, synchronous, 
         messageInfo.Model, messageInfo.UrlResolver)
       {
         this.stream = messageInfo.GetMessageStream();
         this.Writer = new StreamWriter(this.stream);
       }
    }
    private static void CsvWriterDemo()
    {
       EdmEntityType customer = new EdmEntityType("ns", "customer");
       var key = customer.AddStructuralProperty("Id", EdmPrimitiveTypeKind.Int32);
       customer.AddKeys(key);
       customer.AddStructuralProperty("Name", EdmPrimitiveTypeKind.String);
       ODataEntry entry1 = new ODataEntry()
       {
           Properties = new[]
           {
               new ODataProperty(){Name = "Id", Value = 51}, 
               new ODataProperty(){Name = "Name", Value = "Name_A"}, 
           }
       };
       ODataEntry entry2 = new ODataEntry()
       {
           Properties = new[]
           {
               new ODataProperty(){Name = "Id", Value = 52}, 
               new ODataProperty(){Name = "Name", Value = "Name_B"}, 
           }
       };
       var stream = new MemoryStream();
       var message = new Message { Stream = stream };
       // Set Content-Type header value
       message.SetHeader("Content-Type", "text/csv");
       var settings = new ODataMessageWriterSettings
       {
           // Set our resolver here.
           MediaTypeResolver = CsvMediaTypeResolver.Instance,
           DisableMessageStreamDisposal = true,
       };
       using (var messageWriter = new ODataMessageWriter(message, settings))
       {
           var writer = messageWriter.CreateODataFeedWriter(null, customer);
           writer.WriteStart(new ODataFeed());
           writer.WriteStart(entry1);
           writer.WriteEnd();
           writer.WriteStart(entry2);
           writer.WriteEnd();
           writer.WriteEnd();
           writer.Flush();
       }
       stream.Seek(0, SeekOrigin.Begin);
       string msg;
       using (var sr = new StreamReader(stream)) { msg = sr.ReadToEnd(); }
       Console.WriteLine(msg);
    }
