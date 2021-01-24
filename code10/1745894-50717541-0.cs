    public class Program
    {
        // These are C# get-only properties
        // They cannot be assigned a value
        double StartX => algPosition.X;
        double StartY => algPosition.Y:
    }
    ...
    
    algPosition = GetPosition();
    double offset_SourceX = _vertex.Point.X - StartX;
    double offset_SourceY = _vertex.Point.Y - StartY;
    Point position = new Point(algPosition.X + offset_SourceX, algPosition.Y + offset_SourceY);
