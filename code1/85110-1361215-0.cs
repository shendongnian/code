    static class Program
        {
    
            static void Main()
            {
                PrintDocument doc = new PrintDocument();
                doc.PrintController = new StandardPrintController();
                doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
    
                doc.Print();
            }
    
            static void doc_PrintPage(object sender, PrintPageEventArgs e)
            {
                e.Graphics.DrawString("xxx", Control.DefaultFont, Brushes.Black, new PointF(e.PageBounds.Width / 2, e.PageBounds.Height / 2));
            }
        }
