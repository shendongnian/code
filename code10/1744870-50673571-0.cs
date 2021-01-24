    using System.Windows.Media;
    using System.Windows.Shapes;
    string points = "0,0,99,99,99,300,600,300";
    PointCollection collection = PointCollection.Parse(points);
    DrawLine(collection);
    private void DrawLine(PointCollection points)
    {
        Polyline line = new Polyline();
        line.Points = points;
        line.Stroke = new SolidColorBrush(Colors.Black);
        line.StrokeThickness = 3;
        myGrid.Children.Add(line);
    }
