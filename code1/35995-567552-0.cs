	public static void MergePdfFiles(IEnumerable<string> files, string output) {
		iTextSharp.text.Document doc;
		iTextSharp.text.pdf.PdfCopy pdfCpy;
		doc = new iTextSharp.text.Document();
		pdfCpy = new iTextSharp.text.pdf.PdfCopy(doc, new System.IO.FileStream(output, System.IO.FileMode.Create));
		doc.Open();
		foreach (string file in files) {
			// initialize a reader
			iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(file);
			int pageCount = reader.NumberOfPages;
			// set page size for the documents
			doc.SetPageSize(reader.GetPageSizeWithRotation(1));
			for (int pageNum = 1; pageNum <= pageCount; pageNum++) {
				iTextSharp.text.pdf.PdfImportedPage page = pdfCpy.GetImportedPage(reader, pageNum);
				pdfCpy.AddPage(page);
			}
			reader.Close();
		}
		doc.Close();
	}
