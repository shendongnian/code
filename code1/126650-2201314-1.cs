    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace MyApplicationNamespace
    {
        public class MyClass
        {
            public Image CreateWpfImpage()
            {
                GeometryDrawing aGeometryDrawing = new GeometryDrawing();
                aGeometryDrawing.Geometry = new EllipseGeometry(new Point(50, 50), 50, 50);
                aGeometryDrawing.Pen = new Pen(Brushes.Red, 10);
                aGeometryDrawing.Brush = Brushes.Blue;
                DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);
    
                Image anImage = new Image();
                anImage.Source = geometryImage;
                return anImage;
            }
        }
    }
