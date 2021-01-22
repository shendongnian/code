		public static byte[] MergePdf(List<byte[]> pdfs)
		{
			List<PdfSharp.Pdf.PdfDocument> lstDocuments = new List<PdfSharp.Pdf.PdfDocument>();
			foreach (var pdf in pdfs)
			{
				lstDocuments.Add(PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.Import));
			}
			using (PdfSharp.Pdf.PdfDocument outPdf = new PdfSharp.Pdf.PdfDocument())
			{ 
				for(int i = 1; i<= lstDocuments.Count; i++)
				{
					foreach(PdfSharp.Pdf.PdfPage page in lstDocuments[i-1].Pages)
					{
						outPdf.AddPage(page);
					}
				}
				MemoryStream stream = new MemoryStream();
				outPdf.Save(stream, false);
				byte[] bytes = stream.ToArray();
				return bytes;
			}			
		}
