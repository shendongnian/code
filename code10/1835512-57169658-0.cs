void renderPdfToFile(string pdfFilename, string outputImageFilename, int dpi) {
    using (var doc = PdfDocument.Load(pdfFilename)) {               // Load PDF Document from file
        for (int page = 0; page < doc.PageCount; page++) {          // Loop through pages
            using (var img = doc.Render(page, dpi, dpi, false)) {   // Render with dpi and with forPrinting false
                img.Save($"page_{page}_{outputImageFilename}");     // Save rendered image to disc
            }
        }
    }
}
