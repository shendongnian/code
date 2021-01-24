            string fn = Path.GetTempPath() + TmpPrefix +GUID() + ".html";
            
            Document temp = new Document();
            
            // Copy whole old document to new document
            temp.Range().InsertXML(doc.Range().XML);
            // copy IDs assuming the documents are identical and have same amount of elements
            for (int i = 1; i <= temp.Tables.Count; i++) {
                temp.Tables[i].ID = doc.Tables[i].ID;
                Range sRange = doc.Tables[i].Range;
                Range tRange = temp.Tables[i].Range;
                for(int j = 1; j <= tRange.Cells.Count; j++)
                {
                    tRange.Cells[j].ID = sRange.Cells[j].ID;
                }
            }
            for(int i=1; i <= temp.Paragraphs.Count; i++)
            {
                temp.Paragraphs[i].ID = doc.Paragraphs[i].ID;
            }
            // Save new temp document as HTML
            temp.SaveAs2(fn, WdSaveFormat.wdFormatFilteredHTML);
            temp.Close();
            return fn;
