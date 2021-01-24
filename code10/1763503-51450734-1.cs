    private void PrintPage(object sender, PrintPageEventArgs e)
    {
        Image img = bmplist[index];
        Point loc = new Point(100, 100);
        e.Graphics.DrawImage(img, loc);
        index++;
        e.HasMorePages = index < bmpList.Count;
    }
