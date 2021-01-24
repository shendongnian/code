    public void QueryShapes(IEnumerable<Shape> shapes)
    {
        shapes.OfType<Rectangle>().Where(x => x.Width > 100).ToList().ForEach(Draw);
    }
    public void Draw(Rectangle rectangle)
    {
        // drawing
    }
