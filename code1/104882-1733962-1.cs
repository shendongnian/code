    using System.Drawing.Printing;
    private void Form1_Load(object sender, EventArgs e)
    {
        PrintDocument printer = new PrintDocument();
        printer.PrintPage += printer_PrintPage;
        printer.Print();
    }
    void printer_PrintPage(object sender, PrintPageEventArgs e)
    {
        using (Bitmap bmp = new Bitmap(dataGridView1.Width, 
            dataGridView1.Height))
        {
            dataGridView1.DrawToBitmap(bmp,
                new Rectangle(0, 0, bmp.Width, bmp.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
        e.HasMorePages = false;
    }
