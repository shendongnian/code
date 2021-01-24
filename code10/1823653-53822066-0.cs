    public bool Collision(int x1, int y1, int w1, int h1, int x2, int y2, int w2, int h2)
    {
        var rect1 = new System.Drawing.Rectangle(x1,y1,w1,h1);
        var rect2 = new System.Drawing.Rectangle(x2,y2,w2,h2);
        return rect1.IntersectsWith(rect2);
    }
