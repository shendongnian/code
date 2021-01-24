    using (Bitmap bmp = new Bitmap(chart.Width, chart.Height))
    {
        chart.DrawToBitmap(bmp, chart.Bounds); // draw chart into bitmap first!
    
        using (Graphics g = Graphics.FromImage(bmp)) // <--- new
        {
            // now draw label
            String str = series.Tag.ToString();
            Font font = new Font("Microsoft Sans Serif", 32, FontStyle.Bold);
            SizeF strSize = g.MeasureString(str, font);
        
            int strX = 100; int strY = 100;
        
            g.DrawString(str, font, new SolidBrush(Color.Black), strX, strY);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(strX, strY, (int)strSize.Width, (int)strSize.Height));
        
            g.Flush();
        }
        
        bmp.Save(chartPath);
    }
