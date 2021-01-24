                    using (var document = new PdfDocument())
                    {
                        PdfPage page = document.AddPage();
                        XGraphics graph = XGraphics.FromPdfPage(page);
    
                        graph.MUH = PdfFontEncoding.Unicode;
                        graph.MFEH = PdfFontEmbedding.Always;
    
                        // You always need a MigraDoc document for rendering.
                        Document doc = new Document();
                        Section section = doc.AddSection();
    
                        Font font = new Font("Times New Roman", 12);
    
                        foreach (var line in textFileLines)
                        {
                            Paragraph paragraph = section.AddParagraph();
                            paragraph.AddFormattedText(line, font);
                        }
    
                        //save pdf document
                        PdfDocumentRenderer renderer = new PdfDocumentRenderer();
                        renderer.Document = doc;
                        renderer.RenderDocument();
                        renderer.Save(output);
                    }
