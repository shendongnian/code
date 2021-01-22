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
            g.FillPolygon(brush, somePoints);
        }
    }
