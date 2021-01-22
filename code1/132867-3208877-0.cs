            int SizeW = this.Size.Width;
            int SizeH = this.Size.Height;
            int ArcSize = (int)((float)SizeW * 0.40 );
            if (tabType == TabType.LeftTab)
            {
                //Make a six-sided polygon, a rectangle with the "outside" corners cut off.
                //The next step will round the corners with Arcs
                Point[] points = new Point[] { 
                    new Point(SizeW, 0), new Point(ArcSize, 0),
                    new Point(0,ArcSize), new Point(0,SizeH-ArcSize), 
                    new Point(ArcSize,SizeH), new Point(SizeW,SizeH)};
                Byte[] bytes = new byte[] { 
                    1, 1, 
                    1, 1, 
                    1, 1};
                System.Drawing.Drawing2D.FillMode fm =
                    System.Drawing.Drawing2D.FillMode.Winding;
                System.Drawing.Drawing2D.GraphicsPath tempGP =
                    new System.Drawing.Drawing2D.GraphicsPath(points, bytes, fm);
                //add the arcs
                ArcSize = ArcSize * 2;
                tempGP.AddArc(0, 0, ArcSize, ArcSize, -90, -90);
                tempGP.CloseFigure();
                tempGP.AddArc(0, SizeH - ArcSize, ArcSize, ArcSize, 180, -90);
                tempGP.CloseFigure();
                Region tempRegion = new Region(tempGP);
                this.Region = new Region(tempGP);
            }
