    string pdfFilePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\InvoicesSummary\";
    string baseFilename = pdfFilePath + "/" + DateTime.Now.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    string filename = baseFilename;
    int n = 1;
    while (System.IO.File.Exists(filename + ".pdf"))
        filename = baseFilename + "(" + n++ + ")";
    Document document = new Document(PageSize.A4.Rotate(), 25f, 25f, 30f, 160f);
    PdfWriter writer = PdfAWriter.GetInstance(document, new FileStream(filename + ".pdf", FileMode.Create));
    document.Open();
