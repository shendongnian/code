    private void ThumbDragDelta(object sender, DragDeltaEventArgs e)
    {
        var vertex = (Vertex)((Thumb)sender).DataContext;
        vertex.Point = new Point(
            vertex.Point.X + e.HorizontalChange,
            vertex.Point.Y + e.VerticalChange);
    }
