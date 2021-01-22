        public static Bitmap GetStyleBitmap(FeatureLayer fl)
        {
            Feature f = GetFirstFeature(fl);
            if (f == null) return null;
            var style = f.Style;
            Color c;
            var bm = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            PointF[] poly = new PointF[] 
            {
                new PointF(2,5),
                new PointF(5,2),
                new PointF(14,7),
                new PointF(14,14),
                new PointF(2,14),
                new PointF(2,4)
            };
            SimpleLineStyle line = null;
            if (style is CompositeStyle)
                line = ((CompositeStyle)style).AreaStyle.Border as SimpleLineStyle;
            if (style is AreaStyle)
                line = ((AreaStyle)style).Border as SimpleLineStyle;
            if (line != null)
            {
                c = line.Color;
                using (var gr = Graphics.FromImage(bm))
                {
                    gr.DrawPolygon(new Pen(c, 2), poly);
                }
                return bm;
            }
            line = style as SimpleLineStyle;
            if (line != null)
            {
                c = line.Color;
                using (var gr = Graphics.FromImage(bm))
                {
                    gr.DrawLine(new Pen(c, 2), new PointF(2,2), new PointF(14,14));
                }
            }
            return bm;
        }
