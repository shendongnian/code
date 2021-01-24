    {
	string targetFile = "c:\\users\\me\\desktop\\targetFile.docx";
	string appendThisFile = "c:\\users\\me\\desktop\\appendThisFile.docx";
	string newFile = "c:\\users\\me\\desktop\\newFile.docx";
	
	object newFileObj = newfile;  // will need this later to save file
	
	AppendFileToEnd(targetFile, appendThisFile, newFile);
	
	UpdateTOCplusSettings(newFile, ref winWord);
	}
	
	// This method appends  puts a page break at the end of "targetFile" and 
    then appends "appendThisFile."
	// This method requires adding the WordOpenXML SDK - add using nuget
	internal void AppendFileToEnd(string targetFile, string appendThisFile, 
    string newFile)
		{
			File.Delete(newFile);
            File.Copy(targetFile, newFile);
           
            using (WordprocessingDocument myDoc =
                WordprocessingDocument.Open(newFile, true))
            {
                string altChunkId = "AltChunkId1";
                MainDocumentPart mainPart = myDoc.MainDocumentPart;
                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = new 
                  DocumentFormat.OpenXml.Wordprocessing.Paragraph(new 
                  DocumentFormat
                    .OpenXml.Wordprocessing
                    .Run((new DocumentFormat.OpenXml.Wordprocessing.Break() { 
                      Type = BreakValues.Page })));
                mainPart.Document.Body.InsertAfter(para, 
                   mainPart.Document.Body.LastChild);
                AlternativeFormatImportPart chunk =
                    mainPart.AddAlternativeFormatImportPart(
                    AlternativeFormatImportPartType.WordprocessingML, 
                    altChunkId);
                
                using (FileStream fileStream = File.Open(appendThisFile, 
                     FileMode.Open))
                     chunk.FeedData(fileStream);
                
                AltChunk altChunk = new AltChunk();
                altChunk.Id = altChunkId;
                mainPart.Document
                    .Body
                    .InsertAfter(altChunk, mainPart.Document.Body
                    .Elements<DocumentFormat.OpenXml.Wordprocessing
                       .Paragraph>().Last());
               mainPart.Document.Save();
            }
        }
		
	 // This method opens a document and updates the first Table of Contents.
	 // Note that my project already has a Word Interop object, so I pass it in 
           // and use it.  If you don't have an Word object then you need to 
           // create one before opening the doc file)
	 // I also turn off grammar and spelling error - which is a choice of mine      
     internal void UpdateTOCplusSettings(string filename, ref 
         Microsoft.Office.Interop.Word.Application winword)
     {
            Microsoft.Office.Interop.Word.Document wordDocument = 
                winword.Documents.Open(filename);
            wordDocument.ShowGrammaticalErrors = false;
            wordDocument.ShowSpellingErrors = false;
            wordDocument.TablesOfContents[1].Update();
            wordDocument.Save();
      }
