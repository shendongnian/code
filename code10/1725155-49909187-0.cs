    using (var fs = new FileStream("", FileMode.Create, FileAccess.Write))
    {
        using (PdfWriter writer = new PdfWriter("")) //**Implements IDisposable - This should help hugely when used in Parallel**
        {
             var pdf = new PdfDocument(writer);
             var pageSize = PageSize.LETTER;
             var document = new Document(pdf);
              foreach (var chart in data)
              {
                 var page = pdf.AddNewPage(); //When it get's reassigned on the next iteration, Garbage collection will take over
                 PdfCanvas canvas = new PdfCanvas(page, true); //When it get's reassigned on the next iteration, Garbage collection will take over
                 canvas.AddImage(ImageDataFactory.Create(chart.ImageBytes), pageSize, false); //1x Less Object in Memory but you will need to play around with params for precision.
                 chart.DestroyImage();
              }
              document.Close();
        }
    }
