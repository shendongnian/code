        protected override void OnRender(DrawingContext drawingContext)
        {
            EnsureGeometry();
            var boundsGeo = new RectangleGeometry(new Rect(0, 0, ActualWidth, ActualHeight));
            var invertGeo = Geometry.Combine(boundsGeo, _TextGeometry, GeometryCombineMode.Exclude, null);
            drawingContext.PushClip(invertGeo);
            drawingContext.DrawGeometry(null, _Pen, _TextGeometry);
            drawingContext.Pop();
            drawingContext.DrawGeometry(Fill, null, _TextGeometry);
        }
