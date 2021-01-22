    public static void MergePDFs(string targetPath, params string[] pdfs) {
		using(PdfDocument targetDoc = new PdfDocument()){
			foreach (string pdf in pdfs) {
				using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import)) {
					for (int i = 0; i < pdfDoc.PageCount; i++) {
						targetDoc.AddPage(pdfDoc.Pages[i]);
					}
				}
			}
			targetDoc.Save(targetPath);
		}
	}
