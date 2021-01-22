            string xaml = String.Empty;
            FlowDocument doc = new FlowDocument();
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            using (MemoryStream ms = new MemoryStream())
            {
                using(StreamWriter sw = new StreamWriter(ms))
                {
                    sw.Write(from);
                    sw.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
                    range.Load(ms, DataFormats.Rtf);
                }
            }
            
            
            using(MemoryStream ms = new MemoryStream())
            {
                range = new TextRange(doc.ContentStart, doc.ContentEnd);
                range.Save(ms, DataFormats.Xaml);
                ms.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(ms))
                {
                    xaml = sr.ReadToEnd();
                }
            }
            // remove all attribuites in section and remove attribute margin 
            int start = xaml.IndexOf("<Section");
            int stop = xaml.IndexOf(">") + 1;
            string section = xaml.Substring(start, stop);
            xaml = xaml.Replace(section, "<Section xml:space=\"preserve\" HasTrailingParagraphBreakOnPaste=\"False\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">");
            xaml = xaml.Replace("Margin=\"0,0,0,0\"", String.Empty);
