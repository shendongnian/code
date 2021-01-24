    [HttpPost]
    public IActionResult CreatePDF([FromBody] ReportViewModel model) {
        try {
            // region Logic code
            byte[] content = CreateFile(model);
            return File(content, contentType: "application/pdf");
        } catch (System.Exception ex) {
            Serilog.Log.Error($"ReportController.CreatePDF() - {ex}");
            return Json(new { isError = true, errorMessage = ex.Message });
        }
    }
    
    byte[] CreateFile(ReportViewModel model) {
        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream()) {
            // Create the document
            iTextSharp.text.Document document = new iTextSharp.text.Document();
            // Place the document in the PDFWriter
            iTextSharp.text.pdf.PdfWriter PDFWriter =
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, memoryStream);
            // region Initialize Fonts
            // Open the document
            document.Open();
            // region Add content to document
            // Close the document
            document.Close();
            #region Create and Write the file
            // Create the directory
            string directory = $"{_settings.Value.ReportDirectory}\\";
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(directory));
            // region Create the fileName
            // Combine the directory and the fileName
            directory = System.IO.Path.Combine(directory, fileName);
            // Create the file
            byte[] content = memoryStream.ToArray();
            using (System.IO.FileStream fs = System.IO.File.Create(directory)) {
                fs.Write(content, 0, (int)content.Length);
            }
            #endregion
            
            return content;
        }
    
    }
