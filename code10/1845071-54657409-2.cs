    int MovingRectangleIndex;
    List<Rectangle> RectangleList;
    Point StartLocation;
    void PicBoxMouseDown(object sender, MouseEventArgs e)
    {
        for (int i = 0; i < RectangleList.Count; i++) {
            if (condition) {
                MovingRectangleIndex = i;
                StartLocation = e.Location;
                break;
            }
        }
    }
    void PicBoxMouseMove(object sender, MouseEventArgs e)
    {
        var rect = RectangleList[MovingRectangleIndex];
        RectangleList[MovingRectangleIndex] = new Rectangle(
            rect.X + e.X - StartLocation.X,
            rect.Y + e.Y - StartLocation.Y,
            rect.Width, rect.Height);
    }
