            Document doc = Globals.ThisAddIn.Application.ActiveDocument; 
            string headers = "";
            foreach (Section section in doc.Sections)
            {
                foreach (HeaderFooter hf in section.Headers)
                {
                    headers += hf.Range.Text;
                }
            }
            string docText = headers + doc.Range(doc.Content.Start, doc.Content.End).Text;
