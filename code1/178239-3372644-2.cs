    using System;
	using System.IO;
	using iTextSharp.text;
    using iTextSharp.text.pdf;
	// return processed stream (a new MemoryStream)	
    public Stream copyAnnotations(Stream sourcePdfStream, Stream destinationPdfStream)
    {
		// Create new document (IText)
		Document outdoc = new Document(PageSize.A4);
		// Seek to Stream start and create Reader for input PDF
		m.Seek(0, SeekOrigin.Begin);
		PdfReader inputPdfReader = new PdfReader(sourcePdfStream);
		// Seek to Stream start and create Reader for destination PDF
		m.Seek(0, SeekOrigin.Begin);
		PdfReader destinationPdfReader = new PdfReader(destinationPdfStream);
		// Create a PdfWriter from for new a pdf destination stream
		// You should write into a new stream here!
		Stream processedPdf = new MemoryStream();
		PdfWriter pdfw = PdfWriter.GetInstance(outdoc, processedPdf);
		// do not close stream if we've read everything
		pdfw.CloseStream = false;
		// Open document
		outdoc.Open();
		// get number of pages
		int numPagesIn = inputPdfReader.NumberOfPages;
		int numPagesOut = destinationPdfReader.NumberOfPages;
		int max = numPagesIn;
		// Process max number of pages
		if (max<numPagesOut)
		{
			throw new Exception("Impossible - different number of pages");
		}
		int i = 0;
		// Process Pdf pages
		while (i < max)
		{
			// Import pages from corresponding reader
			PdfImportedPage pageIn = writer.inputPdfReader(reader, i);
			PdfImportedPage pageOut = writer.destinationPdfReader(reader, i);
			
			// Get named destinations (annotations
			List<Annotations> toBeAdded = ParseInAndOutAndGetAnnotations(pageIn, pageOut);
			// add your annotations
			foreach (Annotation anno in toBeAdded) pageOut.Add(anno);
			// Add processed page to output PDFWriter
			outdoc.Add(pageOut);
		}
		// PDF creation finished
		outdoc.Close();
		// your new destination stream is processedPdf
		return processedPdf;
	}
