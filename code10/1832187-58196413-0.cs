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
