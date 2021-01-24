    	using System;
		using System.Collections.Generic;
		using System.IO;
		using iTextSharp.text;
		using iTextSharp.text.pdf;
		namespace HelveticSolutions.PdfLibrary
		{
		  public static class PdfMerger
		  {
			/// <summary>
			/// Merge pdf files.
			/// </summary>
			/// <param name="sourceFiles">PDF files being merged.</param>
			/// <returns></returns>
			public static byte[] MergeFiles(List<byte[]> sourceFiles)
			{
			  Document document = new Document();
			  using (MemoryStream ms = new MemoryStream())
			  {
				PdfCopy copy = new PdfCopy(document, ms);
				document.Open();
				int documentPageCounter = 0;
				// Iterate through all pdf documents
				for (int fileCounter = 0; fileCounter < sourceFiles.Count; fileCounter++)
				{
				  // Create pdf reader
				  PdfReader reader = new PdfReader(sourceFiles[fileCounter]);
				  int numberOfPages = reader.NumberOfPages;
				  // Iterate through all pages
				  for (int currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
				  {
					documentPageCounter++;
					PdfImportedPage importedPage = copy.GetImportedPage(reader, currentPageIndex);
					PdfCopy.PageStamp pageStamp = copy.CreatePageStamp(importedPage);
					// Write header
					ColumnText.ShowTextAligned(pageStamp.GetOverContent(), Element.ALIGN_CENTER,
						new Phrase("PDF Merger by Helvetic Solutions"), importedPage.Width / 2, importedPage.Height - 30,
						importedPage.Width < importedPage.Height ? 0 : 1);
					// Write footer
					ColumnText.ShowTextAligned(pageStamp.GetOverContent(), Element.ALIGN_CENTER,
						new Phrase(String.Format("Page {0}", documentPageCounter)), importedPage.Width / 2, 30,
						importedPage.Width < importedPage.Height ? 0 : 1);
					pageStamp.AlterContents();
					copy.AddPage(importedPage);
				  }
				  copy.FreeReader(reader);
				  reader.Close();
				}
				document.Close();
				return ms.GetBuffer();
			  }
			}
		  }
		}
