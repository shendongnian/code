    public class BillPrintController : StandardPrintController
    {
        private readonly DataGridViewRow[] rows;
        private readonly Font printFont;
        private int currenctline = 0;
        private float pageTop = 0;
        private float RowSize = 50;
        public BillPrintController(DataGridViewRow[] rows)
        {
            this.rows = rows;
            printFont = new Font("Courier New", 12);
        }
        public override void OnStartPrint(PrintDocument document, PrintEventArgs e)
        {
            currenctline = 0;
            document.PrintPage += OnPrintPage;
            base.OnStartPrint(document, e);
        }
        public override Graphics OnStartPage(PrintDocument document, PrintPageEventArgs e)
        {
            Graphics graphic = base.OnStartPage(document, e);
            if (graphic != null)
            {
                pageTop = e.MarginBounds.Top;
                Pen pen = new Pen(Brushes.Black, 2);
                float fontHeight = printFont.GetHeight();
                if (currenctline == 0)
                {
                    graphic.DrawString("Suppiler", new Font("Courier New", 20), Brushes.Black, 10, pageTop);
                    graphic.DrawString("Address", printFont, Brushes.Black, 10, pageTop += 40);
                    graphic.DrawString("City", printFont, Brushes.Black, 10, pageTop += 25);
                    graphic.DrawString("Ph: " + "0000000000", printFont, Brushes.Black, 10, pageTop += 25);
                    pageTop += 50;
                }
                graphic.DrawLine(pen, 0, pageTop, e.PageBounds.Width, pageTop);
                string header = "Sr.".PadRight(8) + "Medicine".PadRight(40) + "Qty".PadRight(10) + "Rate".PadRight(15) + "Amount";
                graphic.DrawString(header, printFont, Brushes.Black, 10, pageTop += 5);
                pageTop += 25;
                graphic.DrawLine(pen, 0, pageTop, e.PageBounds.Width, pageTop);
                pageTop += 5;
                pen.Dispose();
            }
            return graphic;
        }
        public override void OnEndPage(PrintDocument document, PrintPageEventArgs e)
        {
            if (!e.HasMorePages)
            {
                Graphics graphic = e.Graphics;
                if (graphic != null)
                {
                    float fontHeight = printFont.GetHeight();
                    graphic.DrawLine(new Pen(Color.Black, 2), 0, 900, 900, 900);
                    graphic.DrawString("Total", printFont, Brushes.Black, 600, 905);
                    graphic.DrawString("Disc.", printFont, Brushes.Black, 600, 925);
                    graphic.DrawString("Payable", printFont, Brushes.Black, 600, 945);
                    Console.WriteLine("End Page");
                }
            }
            base.OnEndPage(document, e);
        }
        public override void OnEndPrint(PrintDocument document, PrintEventArgs e)
        {
            base.OnEndPrint(document, e);
            document.PrintPage -= OnPrintPage;
        }
        private void OnPrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float topMargin = pageTop;
            linesPerPage = (ev.MarginBounds.Height - pageTop) / RowSize;
            var rowHeight = (ev.MarginBounds.Height - pageTop) / linesPerPage;
            while (count < linesPerPage && currenctline < rows.Length)
            {
                string line = currenctline.ToString().PadRight(8) + ("Med " + currenctline.ToString()).PadRight(40) + "Qty".PadRight(10) + "Rate".PadRight(15) + "Amount";
                yPos = topMargin + (count * rowHeight);
                ev.Graphics.DrawString(line, printFont, Brushes.Black, 10, yPos, new StringFormat());
                currenctline++;
                count++;
            }
            // If more lines exist, print another page.
            if (currenctline < rows.Length)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
    }
