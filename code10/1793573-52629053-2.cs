    private static Dictionary<string, KeyValuePair<string, int>> WritePdf(PdfDocument pdf, PdfFont bold, Document document)
        {
            string[] lines = File.ReadAllLines(SRC);
            var title = true;
            var counter = 0;
            PdfOutline outline = null;
            var toc = new Dictionary<string, KeyValuePair<string, int>>();
    
            var t = new Table(1, true);
    
            document.Add(t);
    
                foreach (string line in lines) {
                var p = new Paragraph(line);
                p.SetKeepTogether(true);
                if (title) {
                    string name = "title" + counter++;
                    outline = CreateOutline(outline, pdf, line, name);
    
                    KeyValuePair<string, int> titlePage = new KeyValuePair<string, int>(line, pdf.GetNumberOfPages());
                    p.SetFont(bold)
                        .SetFontSize(12)
                        .SetKeepWithNext(true)
                        .SetDestination(name)
                        .SetNextRenderer(new UpdatePageRenderer(p, titlePage));
    
                    title = false;
    
                    //TODO: 
                    
                    //document.Add(p);
    
                    toc.Add(name, titlePage);
                }
                else {
                    p.SetFirstLineIndent(36);
                    if (string.IsNullOrWhiteSpace(line)) {
                        p.SetMarginBottom(12);
                        title = true;
                    }
                    else {
                        p.SetMarginBottom(0);
                    }
    
                    //TODO: 
                    var c = new Cell().Add(p);
                    t.AddCell(c);
    
                    //document.Add(p);
                }
                    t.Flush();
            }
                t.Complete();
    
            //TODO: 
            
    
            return toc;
        }
