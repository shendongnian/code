    private void Button_Click(object sender, RoutedEventArgs e)
    {
        GeometryDrawing geometryDrawing = new GeometryDrawing();
        geometryDrawing.Geometry =
            new RectangleGeometry
            (
                new Rect(0, 0, viewport3D.ActualWidth, viewport3D.ActualHeight)
            );
        geometryDrawing.Brush =
            new VisualBrush(viewport3D)
            {
                Stretch = Stretch.None,
                AlignmentY = AlignmentY.Bottom
            };
        DrawingImage drawingImage = new DrawingImage(geometryDrawing);
        image.Source = drawingImage;
    }
