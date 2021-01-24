        Microsoft.Office.Interop.Word.Application objword = new Microsoft.Office.Interop.Word.Application();
        objword.WindowState = Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateNormal;
        Microsoft.Office.Interop.Word.Document objDoc = objword.Documents.Add();
        Microsoft.Office.Interop.Word.Range rngFull = objDoc.Content;
        Microsoft.Office.Interop.Word.Range rngTarget = rngFull.Duplicate;
        rngTarget.InsertAfter("\n");
        object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
        rngTarget.Collapse(ref oCollapseEnd);
        String text = "";
        for (int r = 0; r < dgvlib.RowCount; r++)
        {
            text = text + dgvlib.Rows[r].Cells[1].Value.ToString();
            if (dgvlib.Rows[r].Cells[11].Value.ToString()!="")
            {
                text = text +  " Comments:" + dgvlib.Rows[r].Cells[11].Value.ToString() + " ";
                rngTarget.InsertAfter(text);
                text = "";
                rngTarget.Collapse(ref oCollapseEnd);
            }
            else if (dgvlib.Rows[r].Cells[10].Value.ToString() != "")
            {
                text = text +  " ( Bold Text:";
                rngTarget.InsertAfter(text);
                text = "";
                rngTarget.Collapse(ref oCollapseEnd);
                rngTarget.Text = dgvlib.Rows[r].Cells[10].Value.ToString();
                rngTarget.Font.Bold = -1;
                rngTarget.Collapse(ref oCollapseEnd);
                rngTarget.InsertAfter(")");
                rngTarget.Font.Bold = 0;
            }
            text = text + "\n";
        }
        rngFull.Font.Size = 9;
        rngFull.Font.Name = "Arial";
        //para1.Range.Text = text;
        //rngFull.Paragraphs.Add();
        objDoc.SaveAs2(fNameExportWord);
        objword.Visible = true;
