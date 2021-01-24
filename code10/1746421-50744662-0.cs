         private Word.Range writep(Word.Document oDoc, string text, int font, bool bold)
         {
            Word.Paragraph oPara1 = oDoc.Content.Paragraphs.Add();
            Word.Range rng = oPara1.Range;
            rng.Font.Size = font;
            rng.Text = text;
            rng.Font.Name = "Arial";
            oPara1.ReadingOrder = Word.WdReadingOrder.wdReadingOrderRtl;
            int q = 0;
            if (bold)
                q = 1;
            rng.Font.Bold = q;
            rng.InsertParagraphAfter();
            return rng;
        }
        private void button1_Click(object sender, EventArgs e)
        {
          object oMissing = System.Reflection.Missing.Value;
          Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
          Microsoft.Office.Interop.Word.Document oDoc;
          Word.Range rng = null;
          oWord.Visible = true;
          oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);
          rng = writep(oDoc, "The equation is as follows:", 16, true);
          object oCollapseEnd = Word.WdCollapseDirection.wdCollapseEnd;
          rng.Collapse(ref oCollapseEnd);
          rng.Text = "\\sqrt{a^2+b^3}";
          rng.OMaths.Add(rng);
          Word.OMathFunction E = rng.OMaths[1].Functions.Add(rng,
            Word.WdOMathFunctionType.wdOMathFunctionBox);
       }
