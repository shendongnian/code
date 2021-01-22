        using Word = Microsoft.Office.Interop.Word;
       public void Export_Data_To_Word(DataGridView DGV, string filename)
       {
        if (DGV.Rows.Count != 0)
        {
            int RowCount = DGV.Rows.Count;
            int ColumnCount = DGV.Columns.Count;
            Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];
            //add rows
            int r = 0;
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                for (r = 0; r <= RowCount - 1; r++)
                {
                    DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                } //end row loop
            } //end column loop
            Word.Document oDoc = new Word.Document();
            oDoc.Application.Visible = true;
            //page orintation
            oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            dynamic oRange = oDoc.Content.Application.Selection.Range;
            string oTemp = "";
            for (r = 0; r <= RowCount - 1; r++)
            {
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oTemp = oTemp + DataArray[r, c] + "\t";
                }
            }
            //table format
            oRange.Text = oTemp;
            object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
            object ApplyBorders = true;
            object AutoFit = true;
            object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;
            oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                  Type.Missing, Type.Missing, ref ApplyBorders,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, Type.Missing, Type.Missing,
                                  Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
            oRange.Select();
            oDoc.Application.Selection.Tables[1].Select();
            oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
            oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.InsertRowsAbove(1);
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            //header row style
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
            oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;
            //add header row manually
            for (int c = 0; c <= ColumnCount - 1; c++)
            {
                oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
            }
            //table style 
            oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
            oDoc.Application.Selection.Tables[1].Rows[1].Select();
            oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            //header text
            foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                headerRange.Text = "your header text";
                headerRange.Font.Size = 16;
                headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
          //save the file
            oDoc.SaveAs2(filename);
             //NASSIM LOUCHANI
        }  
       }
      private void button_Click(object sender, EventArgs e)
       {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = "Word Documents (*.docx)|*.docx";
        sfd.FileName = "export.docx";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            Export_Data_To_Word(dataGridView1, sfd.FileName); 
        }
       }
