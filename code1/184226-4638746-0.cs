            // open the file
            Word.ApplicationClass app = new Word.ApplicationClass();
            object path = @"c:\Users\name\Desktop\Весь набор.docx";
            object missing = System.Reflection.Missing.Value;
            Word.Document doc = null;
            try
            {
                doc = app.Documents.Open(ref path,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);
                // index
                foreach ( Word.Section section in doc.Sections)
                {
                    Debug.WriteLine("Section index:" + section.Index);
                    Debug.WriteLine("section start: " + section.Range.Start + ", section end: " + section.Range.End);
                }
                bool processNextTable = false;
                foreach (Word.Paragraph paragraph in doc.Paragraphs)
                {
                    string toWrite = paragraph.Range.Text;
                    System.Diagnostics.Debug.WriteLine(toWrite);
                }
                foreach (Word.Table table in doc.Tables)
                {
                    foreach (Word.Row wRow in table.Rows)
                        foreach (Word.Cell cell in wRow.Cells)
                        {
                        }
                }
            }
            finally
            {
                if (doc != null)
                {
                    bool saveChanges = false; // temporary not save any changes
                    app.Quit(ref saveChanges, ref missing, ref missing);
                }
            }
