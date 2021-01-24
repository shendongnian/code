    public void paintRect(object sender, PaintEventArgs e)
            {
                ShapeClass s = new ShapeClass();
                var drawArg = new DrawArgs
                {
                    e = e,
                    // and add your params here
                    x = something,
                    y = something,
                    ///.....
                };
    
                s.paintRectangle(e);
            }
