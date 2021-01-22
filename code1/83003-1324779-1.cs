     public FileStreamResult Print(int id)
     {
         var model = _CustomRepository.Get(id);
         this.ConvertToPDF = true;
         return View( "HtmlView" );
     }
     public override OnResultExecuting( ResultExecutingContext context )
     {
          if (this.ConvertToPDF)
          {
              this.PDFStream = new MemoryStream();
              context.HttpContext.Response.Filter = new PDFStreamFilter( this.PDFStream );
          }
     }
     public override OnResultExecuted( ResultExecutedContext context )
     {
          if (this.ConvertToPDF)
          {
              context.HttpContext.Response.Clear();
              this.PDFStream.Seek( 0, SeekOrigin.Begin );
              Stream byteStream = _PrintService.PrintToPDF( this.PDFStream );
              StreamReader reader = new StreamReader( byteStream );
              context.HttpContext.Response.AddHeader( "content-disposition",
                     "attachment; filename=report.pdf" );
              context.HttpContext.Response.AddHeader( "content-type",
                     "application/pdf" );
              context.HttpContext.Response.Write( reader.ReadToEnd() );
          }
    }
