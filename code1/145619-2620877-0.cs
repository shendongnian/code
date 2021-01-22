       public ActionResult Index(int pageNumber)
        {
           
            ActionResult result = null;
            var path = Server.MapPath("~/Content/BigPdf.pdf");
            
            if (pageNumber == 0)
            {
                result = new FilePathResult(path, "application/pdf");
            }
            else
            {
                string inFile = path;
                string outFile = ".\\ExtractStream.pdf";
                //Creating stream objects holding the PDF files in Open Mode
                var inStream = new FileStream(inFile, FileMode.Open);
                //Creating output stream object that will store the extracted pages as a PDF file
                var outputStream = new MemoryStream();
                //Instantiating PdfFileEditor object
                var editor = new PdfFileEditor();
                //Creating an array of integers having numbers of the pages to be extracted from PDF file
                var pages = new int[] { pageNumber };
                //Calling Extract method
                editor.Extract(inStream, pages, outputStream);
                inStream.Close();
                //Closing output stream
                outputStream.Seek(0, SeekOrigin.Begin);//rewind stream
                var converter = new PdfConverter();
                converter.BindPdf(outputStream);
                converter.DoConvert();
           
                var imageStream = new MemoryStream();
                while (converter.HasNextImage())
                {
                    converter.GetNextImage(imageStream, ImageFormat.Jpeg );
                    
                }
                imageStream.Seek(0, SeekOrigin.Begin);//rewind stream
                result = new FileStreamResult(imageStream, "image/Jpeg");
              
            }
           
            return result;
       
        }
