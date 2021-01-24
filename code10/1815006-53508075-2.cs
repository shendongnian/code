        void setupZoomBox(Chart chart, PictureBox pbox, float zoom)
        {
            ChartArea ca = chart.ChartAreas[0];
            Size sz = chart.ClientSize;
            Size szi = new Size(round(sz.Width * zoom), round(sz.Height * zoom));
            Bitmap bmp2 = null;
            chart.Refresh();
            // original plot area
            Rectangle pao = Rectangle.Round(InnerPlotPositionClientRectangle(chart, ca));
            float ro = 1f * (pao.Width+2) / (pao.Height+2);  // original aspect ratio
            chart.ClientSize = szi;
            chart.Refresh();  // enforce immediate layout
            // zoomed plot area
            Rectangle paz = Rectangle.Round(InnerPlotPositionClientRectangle(chart, ca));
            float rz = 1f * paz.Width / paz.Height;   // zoomed aspect ratio
            // target rectangle, same aspect ratio as unzoomed  area
            int th = paz.Height;
            int tw = round(paz.Height * ro );
            // if (ro > rz)
                //tw = round(th * ro); //else th = round(tw / ro);
            Rectangle tgtR = new Rectangle(0, 0, tw, th);
            // bitmap to hold only the zoomed inner plot area
            bmp2 = new Bitmap(tgtR.Width, tgtR.Height);
            // source area: Only the inner plot area plus 1 line of axis pixels:
            Rectangle srcR = Rectangle.Round(
                               new RectangleF(paz.X - 1, paz.Y - 1, paz.Width + 2, paz.Height + 2));
            // bitmap to hold the whole zoomed chart:
            using (Bitmap bmp = new Bitmap(szi.Width, szi.Height))
            {
                Rectangle drawR = new Rectangle(0, 0, szi.Width, szi.Height);
                chart.DrawToBitmap(bmp, drawR);  // screenshot
                using (Graphics g = Graphics.FromImage(bmp2))  // crop stretched
                     g.DrawImage(bmp, tgtR, srcR, GraphicsUnit.Pixel);
            }
            chart.ClientSize = sz;  // reset chart
            // you should dispose of the old Image if there is one before setting the new one!!
            pbox.Image = bmp2;    
            pbox.ClientSize = bmp2.Size;
        }
