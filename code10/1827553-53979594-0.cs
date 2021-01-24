            int incr = 1000000;
            using (var bmp = new Bitmap(200, 500))
            using (var gr = Graphics.FromImage(bmp))
            {
                DateTime timeBeforeFillRectangle = DateTime.Now;
                for (int i = 0; i < incr; i++)
                {
                    gr.FillRectangle(Brushes.Orange, new Rectangle(0, 0, 100, 300));
                }
                Point[] points = new Point[] { new Point(10, 100), new Point(190, 200), new Point(80, 400) };
                DateTime timeBeforeFillPolygon = DateTime.Now;
                for (int i = 0; i < incr; i++)
                {
                    gr.FillPolygon(Brushes.Orange, points);
                }
                TimeSpan ts1 = timeBeforeFillPolygon.Subtract(timeBeforeFillRectangle);
                TimeSpan ts2 = DateTime.Now.Subtract(timeBeforeFillPolygon);
                Console.WriteLine("FillRectangle seconds: " + ts1.TotalSeconds.ToString());
                Console.WriteLine("FillPolygon seconds: " + ts2.TotalSeconds.ToString());
            }
        }
