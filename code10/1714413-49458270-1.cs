    public static void Run(
        [BlobTrigger("input/{name}", Connection = "AzureWebJobsStorage")] string myBlob, 
        string name, 
        Binder binder)
    {
      var someobject= serializer.Deserialize<Transcript>(myBlob);
      string blobname = (someobject.Results[0].FileName).Substring(0, name.LastIndexOf('.'));
      using (var writer = binder.Bind<TextWriter>(
                  new BlobAttribute($"output/{blobname}")))
      {
          writer.Write(myBlob);
      }
    }
