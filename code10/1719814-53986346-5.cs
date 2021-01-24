        // GET verb
        public IActionResult GenerateDocxBrowser()
        {
            // open xml sdk - docx
            using (MemoryStream mem = new MemoryStream())
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(mem, DocumentFormat.OpenXml.WordprocessingDocumentType.Document, true))
                {
                    wordDoc.AddMainDocumentPart();
                    // siga a ordem
                    Document doc = new Document();
                    Body body = new Body();
                    // 1 paragrafo
                    Paragraph para = new Paragraph();
                    ParagraphProperties paragraphProperties1 = new ParagraphProperties();
                    ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Normal" };
                    Justification justification1 = new Justification() { Val = JustificationValues.Center };
                    ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
                    paragraphProperties1.Append(paragraphStyleId1);
                    paragraphProperties1.Append(justification1);
                    paragraphProperties1.Append(paragraphMarkRunProperties1);
                    Run run = new Run();
                    RunProperties runProperties1 = new RunProperties();
                    Text text = new Text() { Text = "The OpenXML SDK rocks!" };
                    // siga a ordem 
                    run.Append(runProperties1);
                    run.Append(text);
                    para.Append(paragraphProperties1);
                    para.Append(run);
                    // 2 paragrafo
                    Paragraph para2 = new Paragraph();
                    ParagraphProperties paragraphProperties2 = new ParagraphProperties();
                    ParagraphStyleId paragraphStyleId2 = new ParagraphStyleId() { Val = "Normal" };
                    Justification justification2 = new Justification() { Val = JustificationValues.Start };
                    ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
                    paragraphProperties2.Append(paragraphStyleId2);
                    paragraphProperties2.Append(justification2);
                    paragraphProperties2.Append(paragraphMarkRunProperties2);
                    Run run2 = new Run();
                    RunProperties runProperties3 = new RunProperties();
                    Text text2 = new Text();
                    text2.Text = "Teste aqui";
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("Hello"));
                    run2.AppendChild(new Break());
                    run2.AppendChild(new Text("world"));
                    para2.Append(paragraphProperties2);
                    para2.Append(run2);
                    // todos os 2 paragrafos no main body
                    body.Append(para);
                    body.Append(para2);
                    doc.Append(body);
                    wordDoc.MainDocumentPart.Document = doc;
                    wordDoc.Close();
                }
                return File(mem.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "ABC.docx");
            }
        }
