          var file = Request.Files["Image"];
          if ( file != null )
          {
             byte[] fileBytes = new byte[file.ContentLength];
             file.InputStream.Read( fileBytes, 0, file.ContentLength );
             
             // ... now fileBytes[] is filled with the contents of the file.
          }
          else
          {
             // ... error handling here
          }
