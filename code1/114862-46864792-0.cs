    protected Point clickPosition;
    protected Point scrollPosition;
    private void picBoxScan_MouseDown(object sender, MouseEventArgs e)
    {
        this.clickPosition.X = e.X;
        this.clickPosition.Y = e.Y;
    }
    private void picBoxScan_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            scrollPosition.X = panelViewFile.AutoScrollPosition.X;
            scrollPosition.Y = scrollPosition.Y + (clickPosition.Y - e.Y);
            scrollPosition.Y = Math.Min(scrollPosition.Y,panelViewFile.VerticalScroll.Maximum);
            scrollPosition.Y = Math.Max(scrollPosition.Y,panelViewFile.VerticalScroll.Minimum);
            panelViewFile.AutoScrollPosition = scrollPosition;
        }
    }
