    public void Dispose()
      {
         documents.Dispose();
         _stream.Dispose(); // Add this
      }
