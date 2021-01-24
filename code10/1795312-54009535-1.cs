    public static void PrintPage(object sender, PrintPageEventArgs e)
        {
            Stream pageToPrint = m_Streams[m_CurrentPageIndex];
            pageToPrint.Position = 0;
            // Load each page into a Metafile to draw it.
            using (Metafile pageMetaFile = new Metafile(pageToPrint))
            {
                Rectangle adjustedRect = new Rectangle(
                        e.PageBounds.Left - (int)e.PageSettings.HardMarginX,
                        e.PageBounds.Top - (int)e.PageSettings.HardMarginY,
                        e.PageBounds.Width,
                        e.PageBounds.Height);
                // Draw a white background for the report
                e.Graphics.FillRectangle(Brushes.White, adjustedRect);
                // Draw the report content
                e.Graphics.DrawImage(pageMetaFile, adjustedRect);
                // Prepare for next page.  Make sure we haven't hit the end.
                
                m_CurrentPageIndex++;
               
                e.HasMorePages = m_CurrentPageIndex < m_Streams.Count;
                if (m_CurrentPageIndex > m_EndPage) e.HasMorePages = false;
            }
