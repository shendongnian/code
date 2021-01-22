    class _events : PdfPageEventHelper
    {
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            PdfPTable table = new PdfPTable(1);
            //table.WidthPercentage = 100; //PdfPTable.writeselectedrows below didn't like this
            table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin; //this centers [table]
            PdfPTable table2 = new PdfPTable(2);
            //logo
            PdfPCell cell2 = new PdfPCell(Image.GetInstance(@"C:\path\to\file.gif"));
            cell2.Colspan = 2;
            table2.AddCell(cell2);
            //title
            cell2 = new PdfPCell(new Phrase("\nTITLE", new Font(Font.HELVETICA, 16, Font.BOLD | Font.UNDERLINE)));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.Colspan = 2;
            table2.AddCell(cell2);
            PdfPCell cell = new PdfPCell(table2);
            table.AddCell(cell);
            table.WriteSelectedRows(0, -1, document.LeftMargin, 820, writer.DirectContent);
            //could probably substitue something else for 820 here (top margin maybe)
        }
    }
