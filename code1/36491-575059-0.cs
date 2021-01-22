    private void DownloadEmbeddedResource( 
      string resourceName, Assembly resourceAssembly, string downloadFileName )
    {
      using ( Stream stream = resourceAssembly.GetManifestResourceStream( resourceName ) )
      {
        if ( stream != null )
        {
          Response.Clear();
          string headerValue = string.Format( "attachment; filename={0}", downloadFileName );
          Response.AppendHeader( "Content-Disposition:", headerValue );
          Response.AppendHeader( "Content-Length", stream.Length.ToString() );
          Response.ContentType = "text/xml";
          var byteBuffer = new Byte[1];
          using ( var memoryStream = new MemoryStream( byteBuffer, true ) )
          {
            while ( stream.Read( byteBuffer, 0, byteBuffer.Length ) > 0 )
            {
              Response.BinaryWrite( memoryStream.ToArray() );
              Response.Flush();
            }
          }
          Response.End();
        }
      }
    }
