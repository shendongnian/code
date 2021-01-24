    private void druckenPictureBox_Click(object sender, EventArgs e)
    {
        PrintDialog printDialog = new PrintDialog();
        PrintDocument documentToPrint = new PrintDocument();
        printDialog.Document = documentToPrint;
    
        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            StringReader reader = new StringReader(eintragRichTextBox.Text);
            documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
            documentToPrint.Print();
        }
    }
    
    private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
    {
        StringReader reader = new StringReader(eintragRichTextBox.Text);
        float LinesPerPage = 0;
        float YPosition = 0;
        int Count = 0;
        float LeftMargin = e.MarginBounds.Left;
        float TopMargin = e.MarginBounds.Top;
        string Line = null;
        Font PrintFont = this.eintragRichTextBox.Font;
        SolidBrush PrintBrush = new SolidBrush(Color.Black);
    
        LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);
    
        while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
        {
            YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
            e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
            Count++;
        }
    
        if (Line != null)
        {
            e.HasMorePages = true;
        }
        else
        {
            e.HasMorePages = false;
        }
        PrintBrush.Dispose();
    }
