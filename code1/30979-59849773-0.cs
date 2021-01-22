    void ResizeTabs()
    {
        int numTabs = cTabControl.TabCount;
        float totLen = 0;
        using(Graphics g = CreateGraphics())
        {
            // Get total length of the text of each Tab name
            for(int i = 0; i < numTabs; i++)
                totLen += g.MeasureString(cTabControl.TabPages[i].Text, cTabControl.Font).Width;
        }
        int newX = (int)((cTabControl.Width - totLen) / numTabs) / 2;
        cTabControl.Padding = new Point(newX, cTabControl.Padding.Y);
    }
