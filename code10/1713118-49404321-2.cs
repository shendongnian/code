    private Stream _stream; // Add this
    public FlatDocument(Stream stream)
    {
         if (stream == null)
         {
            throw new ArgumentNullException("stream");
         }
         _stream = stream; // Add this
         documents = XDocumentCollection.Open(stream);
         ranges = new List<FlatTextRange>();
         CreateFlatTextRanges();
    }
