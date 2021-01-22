        public FileResult Download()
        {
            string filename = "test.pdf";
            string contentType = "application/pdf";
            //Parameters to file are
            //1. The File Path on the File Server
            //2. The content type MIME type
            //3. The parameter for the file save by the browser
            return File(filename, contentType,"Report.pdf");
        }
