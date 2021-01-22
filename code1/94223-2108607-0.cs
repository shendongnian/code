            private MemoryStream JoinDocuments(List<MemoryStream> subDocuments)
        {
                var sumLength = (from MemoryStream ms in subDocuments select ms.Length).Sum();
                MemoryStream mainDocumentStream = new MemoryStream((int)sumLength);
              // Create a Wordprocessing document.
              using (WordprocessingDocument myDoc = WordprocessingDocument.Create(mainDocumentStream, WordprocessingDocumentType.Document))
              {
                // Add a new main document part.
                MainDocumentPart mainPart = myDoc.AddMainDocumentPart();
                //Create Document tree for simple document.
                mainPart.Document = new Document();
                //Create Body (this element contains other elements that we want to include
                Body body = new Body();
                for (int i = 0; i < subDocuments.Count; i++)
                {
                    var subDocument = subDocuments[i];
                    subDocument.Position = 0;
                    string altChunkId = "AltChunkId" + i;
                    AlternativeFormatImportPart chunk = mainPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                    chunk.FeedData(subDocument);
                    AltChunk altChunk = new AltChunk();
                    altChunk.Id = altChunkId;
                    body.Append(altChunk);
                    Break pageBreak = new Break();
                    pageBreak.Type = BreakValues.Page;
                    body.Append(pageBreak);
                    
                }
                
                mainPart.Document.Append(body);
                // Save changes to the main document part.
                mainPart.Document.Save();
              }
              return mainDocumentStream;
        }
