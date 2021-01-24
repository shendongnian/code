    using (var reader = XmlReader.Create(_, 
      new XmlReaderSettings
      {
          DtdProcessing = DtdProcessing.Ignore,
          ValidationType = ValidationType.None,
          //DtdProcessing = DtdProcessing.Parse,
          //ValidationType = ValidationType.DTD,
          XmlResolver = new XmlUrlResolver
          {
              CachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable),
              //CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore),
          }
      }))
    {
        var doc = XDocument.Load(reader);
        //…
    }
