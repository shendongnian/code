    string pdfFilePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + @"\InvoicesSummary\";
    string filename = pdfFilePath + "/" + DateTime.Now.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
    int n = 1;
    while (System.IO.File.Exists(filename + ".pdf"))
        filename = filename + "(" + n++ + ")";
    Document document = new Document(PageSize.A4.Rotate(), 25f, 25f, 30f, 160f);
    PdfWriter writer = PdfAWriter.GetInstance(document, new FileStream(filename + ".pdf", FileMode.Create));
    document.Open();
