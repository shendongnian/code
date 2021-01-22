    using Pdf2Image;
--
      const string _filename = "/3.pdf";
      // Instantiate the component
      var p2i = new Pdf2ImageConverter(_filename);
    
      // Get page count of a PDF file
      int pages = p2i.GetPageCount();
      Response.Write(pages);
    
      // loops through each page
      for (int i = 1; i < pages; i++)
      {
       // Get size of any page
       int width, height;
       p2i.GetPageSize(i, out width, out height);
    
       // converts the page to PNG format (returns bitmap object with original size)
       var pdfimage = p2i.GetImage(i, width, Pdf2ImageFormat.PNG);
       pdfimage.Save(string.Format("/{0}.png",i));
       pdfimage.Dispose();
      }
