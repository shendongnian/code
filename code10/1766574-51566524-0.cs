    RectangleGeometry Cross1 = new RectangleGeometry(new Rect(0, 0, 15, 110));
    Cross1.Transform = rotateTransform1;
    RectangleGeometry Cross2 = new RectangleGeometry(new Rect(0, 0, 15, 110));
    Cross2.Transform  = rotateTransform2;
    CombinedGeometry c1 = new CombinedGeometry(GeometryCombineMode.Union, Cross1, Cross2);
