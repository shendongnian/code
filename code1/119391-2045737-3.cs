    //Load in an image
    pbTest.Image = Image.FromFile("c:\\Chrysanthemum.jpg");
    
    //Create the graphics surface to draw on
    using (Graphics g = Graphics.FromImage(pbTest.Image))
    {
        using (SolidBrush brush = new SolidBrush(Color.Black))
        {
            //Draw a black rectangle at some coordinates
            g.FillRectangle(brush, new Rectangle(0, 0, 20, 10));
            //Or alternatively, given some points
            //I'm manually creating the array here to prove the point, you'll want to create your array from your datasource.
            Point[] somePoints = new Point[] { new Point(1,1), new Point(20,25), new Point(35, 50), new Point(90, 100) };
            g.FillPolygon(brush, somePoints);
        }
    }
